using Application_Layer.DTOs.Response;
using Application_Layer.Service;
using Domain_Layer.Entities;
using Infrastructure_Layer.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _servicio;
        private readonly JwtUtility _jwt;
        public ClientesController(ClienteService servicio, JwtUtility jwt)
        {
            _servicio = servicio;
            _jwt = jwt;
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
                var token = _jwt.CreateToken(cliente);
                return Ok(token);
            }
            response.Estado = false;
            response.Mensaje = "Los campos no pueden estar vacios.";
            return BadRequest(response);
        }
    }
}
