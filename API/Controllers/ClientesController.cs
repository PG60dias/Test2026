using Data.DTOs;
using Data.Modelo;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<ClienteDTO> Get()
        {
			return _service.Repository.GetAllClientes();
		}

		[HttpGet("{id}")]
		public ActionResult<ClienteDTO> Get(int id)
		{
			var cliente = _service.Repository.GetCliente(id);
			return Ok(cliente);
		}

		[HttpPost]
		public ActionResult <ClienteDTO> Post([FromBody] Cliente cliente)
		{
			_service.Repository.AddCliente(cliente);

            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			try
			{
				var cliente = _service.Repository.GetCliente(id);
				if (cliente == null)
				{
					return NotFound($"No se encontró el cliente con ID {id}");
				}

				_service.Repository.DeleteCliente(id);

				return NoContent();
			}
			catch (DbUpdateException ex)
			{
				return Conflict("No se puede eliminar el cliente");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error interno: {ex.Message}");
			}
		}

		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] Cliente cliente)
		{
			if (id != cliente.Id)
				return BadRequest("El ID del cliente no coincide con el del cuerpo.");

			var existente = _service.Repository.GetCliente(id);

			if (existente == null)
				return NotFound("Cliente no encontrado.");

			existente.Nombre = cliente.Nombre;
			existente.Direccion = cliente.Direccion;
			existente.Email = cliente.Email;
			existente.Telefono = cliente.Telefono;
			existente.Categoria= cliente.Categoria;


			_service.Repository.UpdateCliente(existente);

			return NoContent();
		}
	}
}
