using Application_Layer.DTOs.Response;
using Domain_Layer.Entities;
using Domain_Layer.Interface;

namespace Application_Layer.Service
{
    public class ClienteService
    {
        private readonly IClienteRepository _cliente;
        public ClienteService(IClienteRepository cliente)
        {
            _cliente = cliente;
        }

        public async Task<Response<Cliente>> CrearCliente(Cliente cliente) 
        {
            var emailExiste = await _cliente.GetFirstOrDefault(c => c.Email == cliente.Email);
            if (emailExiste != null) 
            {
                return new Response<Cliente>()
            {
                Estado = false,
                Mensaje = "El email ya está registrado.",
                Entidad = null
            };
            }
            await _cliente.Add(cliente);
            await _cliente.SaveAsync();

            return new Response<Cliente>()
            {
                Estado = true,
                Mensaje = "Cliente creado correctamente.",
                Entidad = null
            };
        }
    }
}
