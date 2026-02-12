using Data.Common;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoriasProductosController(TestDbContext context) : ControllerBase
	{
		private readonly TestDbContext _context = context;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CategoriaProducto>>> Get()
		{
			return await _context.CategoriasProductos.ToListAsync();
		}
	}
}