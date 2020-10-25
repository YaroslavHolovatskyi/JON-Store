using JON_Store.DomainModel.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JON_Store.DataAccess.Repositories.Abstract
{
    public class SoftDeleteRepositoryBase<TEntity> : RepositoryBase<TEntity>
        where TEntity : class, ISoftDeleted, IEntity
    {
        public SoftDeleteRepositoryBase(DbContext dbContext) 
            : base(dbContext) { }

        public override int Count()
        {
            return FilterNotDeleted(_dbSet).Count();
        }
        public override bool Contains(int id)
        {
            return _dbSet.Any(e => e.Id == id && !e.IsDeleted);
        }

        public override int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return FilterNotDeleted(_dbSet).Count(predicate);
        }
        public override TEntity Get(int id)
        {
            return _dbSet.SingleOrDefault(e => e.Id == id && !e.IsDeleted);
        }
        public override IReadOnlyCollection<TEntity> GetList()
        {
            return FilterNotDeleted(_dbSet).ToList();
        }

        public override async Task<IReadOnlyCollection<TEntity>> GetListAsync()
        {
            return await FilterNotDeleted(_dbSet).ToListAsync();
        }

        public override void Delete(TEntity entityToDelete)
        {
            if (entityToDelete == null) throw new ArgumentNullException(nameof(entityToDelete));

            entityToDelete.IsDeleted = true;
        }
    }
}
