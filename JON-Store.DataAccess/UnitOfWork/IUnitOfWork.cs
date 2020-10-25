using System.Collections.Generic;
using System.Threading.Tasks;

namespace JON_Store.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        TRepositoryInterface GetRepository<TRepositoryInterface>();

        void Update<TEntity>(TEntity entityToUpdate) where TEntity : class;
        void UpdateRange<TEntity>(IEnumerable<TEntity> entitiesToUpdate) where TEntity : class;

        int Complete();
        Task<int> CompleteAsync();
    }
}
