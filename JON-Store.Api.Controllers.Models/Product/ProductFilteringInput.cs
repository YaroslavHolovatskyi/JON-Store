using JON_Store.Api.Controllers.Models.Enums;
using System;

namespace JON_Store.Api.Controllers.Models
{
    public class ProductFilteringInput
    {
        public ProductSortingOptions Sorting { get; set; }
        public int Page { get; set; }
        public int Amount { get; set; }
    }
}
