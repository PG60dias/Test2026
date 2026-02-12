using Data.Common;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ArticulosController(TestDbContext context) : ControllerBase
	{
		private readonly TestDbContext _context = context;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Articulo>>> Get()
		{
			return await _context.Articulos
				.Include(a => a.Categoria)
				.ToListAsync();
		}
	}
}