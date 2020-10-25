using JON_Store.Api.Controllers.Models;
using JON_Store.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JON_Store.DataAccess.Repositories.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {

        int Count(ProductFilteringInput filteringInput);
        Task<Product> GetAsync(int id);
        IReadOnlyCollection<Product> GetList(int id);
    }
}
