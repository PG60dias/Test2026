using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	public partial class ExportController : Controller
	{

			public IQueryable ApplyQuery<T>(IQueryable<T> items, IQueryCollection query = null) where T : class
		{
			IQueryable result = items;

			try
			{
				if (query != null)
				{
					// 1. Expand (Debe ir antes que el Select)
					if (query.ContainsKey("$expand"))
					{
						var expands = query["$expand"].ToString().Split(',');
						foreach (var e in expands)
						{
							items = items.Include(e.Trim());
						}
						result = items;
					}

					// 2. Filter
					var filter = query.ContainsKey("$filter") ? query["$filter"].ToString() : null;
					if (!string.IsNullOrEmpty(filter))
					{
						result = result.Where(filter);
					}

					// 3. OrderBy
					if (query.ContainsKey("$orderBy"))
					{
						result = result.OrderBy(query["$orderBy"].ToString());
					}
					return result;
				}
			}
			catch (Exception ex)
			{
				// Esto te permite ver el error real en la consola de la API
				Console.WriteLine($"ERROR EN APPLYQUERY: {ex.Message}");
				throw;
			}

			return result;
		}

		// Genera el archivo Excel (.xlsx) usando Open XML
		public FileStreamResult ToExcel(IQueryable query, string fileName = null)
		{
			var columns = GetProperties(query.ElementType);
			var stream = new MemoryStream();

			using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
			{
				var workbookPart = document.AddWorkbookPart();
				workbookPart.Workbook = new Workbook();

				var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
				worksheetPart.Worksheet = new Worksheet();

				var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
				GenerateWorkbookStylesPartContent(workbookStylesPart);

				var sheets = workbookPart.Workbook.AppendChild(new Sheets());
				var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
				sheets.Append(sheet);

				var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

				// Fila de Cabecera
				var headerRow = new Row();
				foreach (var column in columns)
				{
					var headerTitle = column.Key
				.Replace("CategoriaNavigation_Nombre", "Categoría") // Traduce el nombre técnico a algo legible
				.Replace("_", " "); // Quita los guiones bajos de otras columnas con alias

					headerRow.Append(new Cell()
					{
						CellValue = new CellValue(headerTitle),
						DataType = new EnumValue<CellValues>(CellValues.String)
					});
				}
				sheetData.AppendChild(headerRow);

				// Filas de Datos
				foreach (var item in query)
				{
					var row = new Row();
					foreach (var column in columns)
					{
						var value = GetValue(item, column.Key);
						var stringValue = $"{value}".Trim();
						var cell = new Cell();

						// Determinamos el tipo de dato para el formato de Excel
						var underlyingType = column.Value.IsGenericType && column.Value.GetGenericTypeDefinition() == typeof(Nullable<>)
							? Nullable.GetUnderlyingType(column.Value) : column.Value;
						var typeCode = Type.GetTypeCode(underlyingType);

						if (typeCode == TypeCode.DateTime)
						{
							if (!string.IsNullOrWhiteSpace(stringValue))
							{
								cell.CellValue = new CellValue() { Text = ((DateTime)value).ToOADate().ToString(CultureInfo.InvariantCulture) };
								cell.DataType = new EnumValue<CellValues>(CellValues.Number);
								cell.StyleIndex = 1U; // Índice del estilo de fecha definido abajo
							}
						}
						else if (IsNumeric(typeCode))
						{
							cell.CellValue = new CellValue(Convert.ToString(value, CultureInfo.InvariantCulture));
							cell.DataType = new EnumValue<CellValues>(CellValues.Number);
						}
						else
						{
							cell.CellValue = new CellValue(stringValue);
							cell.DataType = new EnumValue<CellValues>(CellValues.String);
						}
						row.Append(cell);
					}
					sheetData.AppendChild(row);
				}
				workbookPart.Workbook.Save();
			}

			stream.Seek(0, SeekOrigin.Begin);
			var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
			result.FileDownloadName = (fileName ?? "Export") + ".xlsx";
			return result;
		}

		// Helpers de reflexión y tipos
		private static object GetValue(object target, string name) => target.GetType().GetProperty(name).GetValue(target);

		private static IEnumerable<KeyValuePair<string, Type>> GetProperties(Type type)
		{
			return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => p.CanRead && IsSimpleType(p.PropertyType))
				.Select(p => new KeyValuePair<string, Type>(p.Name, p.PropertyType));
		}

		private static bool IsSimpleType(Type type)
		{
			var underlyingType = Nullable.GetUnderlyingType(type) ?? type;
			return type.IsPrimitive || new[] { typeof(string), typeof(decimal), typeof(DateTime), typeof(Guid) }.Contains(underlyingType);
		}

		private static bool IsNumeric(TypeCode typeCode) =>
			new[] { TypeCode.Decimal, TypeCode.Double, TypeCode.Int32, TypeCode.Int64, TypeCode.Single }.Contains(typeCode);

		private void GenerateWorkbookStylesPartContent(WorkbookStylesPart workbookStylesPart)
		{
			Stylesheet stylesheet = new Stylesheet();
			// Definición básica de estilos (necesaria para formatos de fecha, etc.)
			Fonts fonts = new Fonts(new Font(new FontSize() { Val = 11D }, new Color() { Theme = 1U }, new FontName() { Val = "Calibri" }));
			Fills fills = new Fills(new Fill(new PatternFill() { PatternType = PatternValues.None }), new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }));
			Borders borders = new Borders(new Border());
			CellFormats cellFormats = new CellFormats(
				new CellFormat(), // Default
				new CellFormat() { NumberFormatId = 14U, ApplyNumberFormat = true } // Date
			);
			stylesheet.Append(fonts, fills, borders, cellFormats);
			workbookStylesPart.Stylesheet = stylesheet;
		}
	}
}