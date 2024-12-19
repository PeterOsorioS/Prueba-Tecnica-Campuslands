using Domain_Layer.Entities;

namespace Domain_Layer.Interface
{
    public interface IProductoRepository : IRepository<Producto>
    {
        Task Update(Producto producto);
    }
}
