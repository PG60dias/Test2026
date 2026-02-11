using Data.Common;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LogsController(TestDbContext context) : ControllerBase
	{
		private readonly TestDbContext _context = context;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Log>>> GetLogs()
		{
			// Retorna los logs ordenados por fecha descendente para ver lo más reciente primero
			return await _context.Set<Log>()
								 .OrderByDescending(l => l.Fecha)
								 .ToListAsync();
		}

		[HttpPost]
		public async Task<IActionResult> PostLog(Log log)
		{
			_context.Set<Log>().Add(log);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}