using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Interface
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task<T> Get(int id);
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null);
        Task<T> GetFirstOrDefault(
           Expression<Func<T, bool>>? filter = null,
           string? includeProperties = null);

        Task SaveAsync();

    }
}
