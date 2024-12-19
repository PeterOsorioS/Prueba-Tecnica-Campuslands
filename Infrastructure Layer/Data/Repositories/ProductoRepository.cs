using Domain_Layer.Entities;
using Domain_Layer.Interface;

namespace Infrastructure_Layer.Data.Repositories
{
    public class ProductoRepository : Repository<Producto> , IProductoRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Task Update(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
