using JON_Store.Api.Controllers.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JON_Store.Services.Interfaces
{
    public interface IProductService
    {
        //bool Contains(int productId);
        Task<GetSingleProductResponseModel> GetProductAsync(int productId);
        //int GetTotalProductAmount(ProductListRequestModel request);
        //IReadOnlyCollection<ProductListResponseModel> GetClients(ProductListRequestModel productListRequestModel);
        //Task<bool> AddProductAsync(CreateProductRequestModel createClientRequestModel);
        //Task<bool> DeleteAsync(int productId);
    }
}
