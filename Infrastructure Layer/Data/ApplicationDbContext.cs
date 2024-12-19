using Domain_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        DbSet<Cliente> clientes { get; set; }
        DbSet<Producto> productos { get; set; }
        DbSet<Pedido> pedidos { get; set; }
        DbSet<PedidoProducto> pedidoProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configuracion cliente
            builder.Entity<Cliente>()
                .HasKey(cliente => cliente.Id);

            builder.Entity<Cliente>()
                .Property(cliente => cliente.Email)
                .IsRequired();


            // Configuracion Productos
            builder.Entity<Producto>()
                .HasKey(producto => producto.Id);


            // Configuracion Pedidos
            builder.Entity<Pedido>()
                .HasKey(pedido => pedido.Id);

            builder.Entity<Pedido>()
                .HasOne(pedido => pedido.Cliente)
                .WithMany(cliente => cliente.Pedidos)
                .HasForeignKey(pedido => pedido.ClienteId);


            // Configuracion PedidoProductos
            builder.Entity<PedidoProducto>()
                .HasKey(pedidoP => new { pedidoP.ProductoId, pedidoP.PedidoId });

            builder.Entity<PedidoProducto>()
              .HasOne(pedidoP => pedidoP.Pedido)
              .WithMany(pedido => pedido.PedidoProductos)
              .HasForeignKey(pedidoP => pedidoP.PedidoId);

            builder.Entity<PedidoProducto>()
              .HasOne(pedidoP => pedidoP.Producto)
              .WithMany(pedido => pedido.PedidoProductos)
              .HasForeignKey(pedidoP => pedidoP.ProductoId);

            base.OnModelCreating(builder);
        }
    }
}
