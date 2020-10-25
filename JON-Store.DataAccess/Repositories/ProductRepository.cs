using JON_Store.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using JON_Store.DomainModel;
using System.Collections.Generic;
using System.Linq;
using JON_Store.Api.Controllers.Models;
using JON_Store.Api.Controllers.Models.Enums;
using System;
using System.Threading.Tasks;

namespace JON_Store.DataAccess.Repositories
{
    public class ProductRepository : SoftDeleteRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DbContext context)
            : base(context) { }

        public int Count(ProductFilteringInput filteringInput)
        {
            IQueryable<Product> query = _dbSet;
            query = FilterNotDeleted(query);
            return query.Count();
        }

        public IReadOnlyCollection<Product> GetList(int managerId)
        {
            IQueryable<Product> query = _dbSet;

            query = FilterNotDeleted(query);

            return query.ToList();
        }

        public IReadOnlyCollection<Product> GetList(ProductFilteringInput filteringInput)
        {
            IQueryable<Product> query = _dbSet;

            query = FilterNotDeleted(query);
            query = SortQuery(query, filteringInput);
            query = PageQuery(query, filteringInput);

            return query.ToList();
        }
        private IQueryable<Product> SortQuery(IQueryable<Product> query, ProductFilteringInput filteringInput)
        {
            switch (filteringInput.Sorting)
            {
                case ProductSortingOptions.Alphabetical: return query.OrderBy(c => c.Name);
                case ProductSortingOptions.New: return query.OrderBy(c => c.CreationDate);
                case ProductSortingOptions.Old: return query.OrderByDescending(c => c.CreationDate);

                default: throw new ArgumentException("Not expected sorting type");
            }
        }

        private IQueryable<Product> PageQuery(IQueryable<Product> query, ProductFilteringInput filteringInput)
        {
            return query
                .Skip((filteringInput.Page - 1) * filteringInput.Amount)
                .Take(filteringInput.Amount);
        }
        public override Product Get(int id)
        {
            return _dbSet
                .Include(c => c.Price)
                .Include(c => c.Description)
                .Include(c => c.Price)
                .Include(c => c.CreationDate)
                .SingleOrDefault(product => product.Id == id
                                 && product.IsDeleted == false);
        }
        public Task<Product> GetAsync(int id)
        {
            return _dbSet
                .Include(c => c.Price)
                .Include(c => c.Description)
                .Include(c => c.Price)
                .Include(c => c.CreationDate)
                .SingleOrDefaultAsync(product => product.Id == id
                                      && product.IsDeleted == false);
        }


    }
}
