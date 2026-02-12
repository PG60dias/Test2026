using Data.Modelo;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoriasController : ControllerBase
	{
		private readonly CategoriaService _service;

		public CategoriasController(CategoriaService service)
		{
			_service = service;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Categoria>> GetCategorias()
		{
			var lista = _service.GetAllCategorias();
			return Ok(lista);
		}
	}
}