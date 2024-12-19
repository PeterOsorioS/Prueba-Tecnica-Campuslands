using Domain_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

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
            builder.Entity<Cliente>(entity =>
            {
                entity.HasKey(cliente => cliente.Id);

                entity.HasIndex(cliente => cliente.Nombre)
                .IsUnique();

                entity.Property(cliente => cliente.Email)
                .IsRequired();

                entity.HasIndex(cliente => cliente.Email)
                .IsUnique();

                entity.Property(u => u.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");
            });



            // Configuracion Productos
            builder.Entity<Producto>(entity =>
            {
                entity.HasKey(producto => producto.Id);

                entity.Property(producto => producto.Nombre)
                .IsRequired();

                entity.Property(producto => producto.Precio)
                .IsRequired()
                .HasDefaultValue(0);

                entity.Property(producto => producto.stock)
                .IsRequired()
                .HasDefaultValue(0);
            });


            // Configuracion Pedidos
            builder.Entity<Pedido>(entity =>
            {
               
               entity.HasKey(pedido => pedido.Id);

                entity.HasOne(pedido => pedido.Cliente)
                    .WithMany(cliente => cliente.Pedidos)
                    .HasForeignKey(pedido => pedido.ClienteId);
            });


            // Configuracion PedidoProductos
            builder.Entity<PedidoProducto>(entity =>
            {
                entity.HasKey(pedidoP => new { pedidoP.ProductoId, pedidoP.PedidoId });

                entity.HasOne(pedidoP => pedidoP.Pedido)
                  .WithMany(pedido => pedido.PedidoProductos)
                  .HasForeignKey(pedidoP => pedidoP.PedidoId);

                entity.HasOne(pedidoP => pedidoP.Producto)
                  .WithMany(pedido => pedido.PedidoProductos)
                  .HasForeignKey(pedidoP => pedidoP.ProductoId);
            });
          
        }
    }
}
