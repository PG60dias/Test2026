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

	    [HttpGet(Name = "Clientes")]
        public IEnumerable<Cliente> Get()
        {
			return _service.Repository.GetAllClientes();
		}
    }
}
