using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int stock { get; set; }
        public DateTime FechaCreacion { get; set; }
        public IList<PedidoProducto> PedidoProductos { get; set; }
    }
}
