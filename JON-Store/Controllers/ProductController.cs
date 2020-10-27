using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JON_Store.Api.Controllers.Models.Paging;
using JON_Store.Api.Controllers.Models.Product;
using JON_Store.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JON_Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products/{productId}")]
        public async Task<IActionResult> GetClient(int clientId)
        {
            var response = await _productService.GetProductAsync(clientId);

            return response != null ? (IActionResult)Ok(response) : NotFound();
        }
        //[HttpGet("products")]
        //public IActionResult GetProducts(ProductListRequestModel clientListRequestModel)
        //{
        //    var totalAmount = _productService.GetTotalProductAmount(clientListRequestModel);
        //    var responseData = _productService.GetClients(clientListRequestModel);
        //    var response = new PagingResponseModel<IReadOnlyCollection<ProductListResponseModel>>(responseData, totalAmount);

        //    return Ok(response);
        //}
        //[HttpPost("addClient")]
        //public async Task<IActionResult> AddProduct([FromBody] CreateProductRequestModel createProductRequestModel)
        //{
        //    var createResult = await _productService.AddProductAsync(createProductRequestModel);
        //    return createResult ? (IActionResult)Ok() : BadRequest("Client is not added");
        //}

        ////[HttpPut("updateClient")]
        ////public async Task<IActionResult> UpdateClient([FromBody] UpdateProductRequestModel updateProductRequestModel)
        ////{
        ////    if (!_productService.Contains(updateProductRequestModel.UpdateClientDto.Id)) return BadRequest();
        ////    var updateResult = await _productService.UpdateProductAsync(updateProductRequestModel);
        ////    return updateResult ? (IActionResult)Ok() : BadRequest("Client is not updated");
        ////}

        //[HttpDelete("clients/{clientId}")]
        //public async Task<IActionResult> Delete(int clientId)
        //{
        //    if (!_productService.Contains(clientId)) return NotFound();
        //    var deleteResult = await _productService.DeleteAsync(clientId);
        //    return deleteResult ? (IActionResult)Ok() : BadRequest("Client is not deleted");
        //}
    }
}
