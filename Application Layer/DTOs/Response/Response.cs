using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.DTOs.Response
{
    public class Response<T> where T : class
    {
        public bool Estado {  get; set; }
        public string? Mensaje { get; set; }
        public T? Entidad { get; set; }
    }
}
