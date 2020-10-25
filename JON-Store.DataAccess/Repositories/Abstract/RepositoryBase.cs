using JON_Store.DomainModel.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JON_Store.DataAccess.Repositories.Abstract
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public IQueryable<TEntity> Query => _dbSet;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        protected IQueryable<TSoftDeletedEntity> FilterNotDeleted<TSoftDeletedEntity>(IQueryable<TSoftDeletedEntity> query)
            where TSoftDeletedEntity : ISoftDeleted
        {
            return query.Where(c => c.IsDeleted == false);
        }
        public virtual int Count()
        {
            return _dbSet.Count();
        }
        public virtual bool Contains(int id)
        {
            return _dbSet.Any(e => e.Id == id);
        }
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Count(predicate);
        }

        public virtual void Delete(object id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            var entityToDelete = _dbSet.Find(id);

            if (entityToDelete == null) throw new InvalidOperationException("There is no records with such id");
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (entityToDelete == null) throw new ArgumentNullException(nameof(entityToDelete));

            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IReadOnlyCollection<TEntity> GetList()
        {
            return _dbSet.ToList();
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetListAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public virtual Task InsertAsync(TEntity entity)
        {
            return _dbSet.AddAsync(entity);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            if (_dbContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbContext.Set<TEntity>().Attach(entityToUpdate);
            }
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}
