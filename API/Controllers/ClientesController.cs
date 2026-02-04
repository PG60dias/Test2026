using Data.Modelo;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {

		private readonly ClienteService _service;
        
        public ClientesController(ClienteService service)
        {
            _service = service;
        }

	    [HttpGet]
        public IEnumerable<Cliente> Get()
        {
			return _service.Repository.GetAllClientes();
		}

		[HttpGet("{id}")]
		public ActionResult<Cliente> Get(int id)
		{
			var cliente = _service.Repository.GetCliente(id);
			return Ok(cliente);
		}

		[HttpPost]
		public ActionResult <Cliente> Post([FromBody] Cliente cliente)
		{
			_service.Repository.AddCliente(cliente);

            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
		}

		[HttpDelete]
		public ActionResult Delete([FromBody] Cliente body)
		{
			int id = body.Id;
			_service.Repository.DeleteCliente(id);
			return NoContent();
		}

	}
}
