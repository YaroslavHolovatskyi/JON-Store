using JON_Store.Api.Controllers.Models.Enums;

namespace JON_Store.Api.Controllers.Models.Product
{
    public class ProductListRequestModel
    {
        public ProductSortingOptions? Sorting { get; set; }
    }
}
