using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TobaccoStore.Entities;

namespace TobaccoStore.Data
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        IQueryable<T> GetAll(string[] includes);
   
    }
}