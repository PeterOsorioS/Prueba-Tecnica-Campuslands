using Domain_Layer.Entities;
using Domain_Layer.Interface;

namespace Infrastructure_Layer.Data.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        private readonly ApplicationDbContext _db;
        public PedidoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
