using Application_Layer.DTOs.Response;
using Application_Layer.Service;
using Domain_Layer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _servicio;
        public ClientesController(ClienteService servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<ActionResult<Response<Cliente>>> Crear([FromBody] Cliente cliente)
        {
            var response = await _servicio.CrearCliente(cliente);

            if (cliente != null)
            {
                if (response.Estado == false) 
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            response.Estado = false;
            response.Mensaje = "Los campos no pueden estar vacios.";
            return BadRequest(response);
        }
    }
}
