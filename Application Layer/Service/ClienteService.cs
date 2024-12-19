using Domain_Layer.Entities;
using Domain_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Service
{
    public class ClienteService
    {
        private readonly IClienteRepository _cliente;
        public ClienteService(IClienteRepository cliente)
        {
            _cliente = cliente;
        }

        public async Task<string> GetCliente(Cliente cliente) 
        {
            var emailExiste = await _cliente.GetFirstOrDefault(c => c.Email == cliente.Email);
            if (emailExiste != null) 
            {
                throw new Exception("El email ya está registrado.");
            }
            await _cliente.Add(cliente);
            await _cliente.SaveAsync();

            return "";
        }
    }
}
