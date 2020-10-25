using JON_Store.Api.Controllers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JON_Store.DataAccess.Repositories.Abstract
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query { get; }
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        TEntity Get(int id);
        IReadOnlyCollection<TEntity> GetList();
        Task<IReadOnlyCollection<TEntity>> GetListAsync();
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entityToUpdate);


    }
}
