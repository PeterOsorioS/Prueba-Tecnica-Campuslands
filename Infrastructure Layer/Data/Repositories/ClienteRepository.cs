using Domain_Layer.Entities;
using Domain_Layer.Interface;

namespace Infrastructure_Layer.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _db;
        public ClienteRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }
    }
}
