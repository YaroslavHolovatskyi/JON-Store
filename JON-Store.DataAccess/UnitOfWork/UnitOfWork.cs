using JON_Store.DataAccess.Repositories;
using JON_Store.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JON_Store.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _dataBaseContext;
        private readonly ConcurrentDictionary<Type, object> _repositories;
        private readonly IDictionary<Type, Func<object>> _repositoriesFactory;
        public UnitOfWork(DbContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
            _repositoriesFactory = InitializeRepositoriesFactory();
            _repositories = new ConcurrentDictionary<Type, object>();
        }
        private IDictionary<Type, Func<object>> InitializeRepositoriesFactory()
        {
            return new Dictionary<Type, Func<object>>()
            {
                [typeof(IProductRepository)] = () => new ProductRepository(_dataBaseContext)
            };
        }
        public void Dispose()
        {
            _dataBaseContext.Dispose();
        }
        public TRepositoryInterface GetRepository<TRepositoryInterface>()
        {
            Type key = typeof(TRepositoryInterface);
            return (TRepositoryInterface)_repositories.GetOrAdd(key, _repositoriesFactory[key].Invoke());
        }

        public void Update<TEntity>(TEntity entityToUpdate) where TEntity : class
        {
            if (_dataBaseContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dataBaseContext.Set<TEntity>().Attach(entityToUpdate);
            }
            _dataBaseContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public void UpdateRange<TEntity>(IEnumerable<TEntity> entitiesToUpdate) where TEntity : class
        {
            _dataBaseContext.UpdateRange(entitiesToUpdate);
        }

        public int Complete()
        {
            return _dataBaseContext.SaveChanges();
        }
        public Task<int> CompleteAsync()
        {
            return _dataBaseContext.SaveChangesAsync();
        }
    }
}
