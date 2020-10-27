using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JON_Store.Api.Controllers.Models;
using JON_Store.Api.Controllers.Models.Product;
using JON_Store.DataAccess.Repositories.Abstract;
using JON_Store.DataAccess.UnitOfWork;
using JON_Store.DomainModel;
using JON_Store.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JON_Store.Services.Implamentations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = _unitOfWork.GetRepository<IProductRepository>();
        }
        //public int GetTotalProductAmount(ProductListRequestModel request)
        //{
        //    return _productRepository
        //        .Count(_mapper.Map<ProductFilteringInput>(request));
        //}
        public async Task<GetSingleProductResponseModel> GetProductAsync(int productId)
        {
            var product = await _productRepository.GetAsync(productId);
            return _mapper.Map<GetSingleProductResponseModel>(product);
        }
        //public IReadOnlyCollection<ProductListResponseModel> GetClients(ProductListRequestModel productListRequestModel)
        //{
        //    //return _productRepository
        //    //    .GetList(_mapper.Map<ProductFilteringInput>(productListRequestModel))
        //    //    .Select(_mapper.Map<Product, ProductListResponseModel>)
        //    //    .ToArray();
        //    return null;
        //}
        //public IReadOnlyCollection<ProductResponseModel> GetProducts(int id)
        //{
        //    return _productRepository
        //        .GetList(id)
        //        .Select(_mapper.Map<Product, ProductResponseModel>)
        //        .ToArray();
        //}
        //public async Task<bool> AddProductAsync(CreateProductRequestModel createClientRequestModel)
        //{
        //    var client = _mapper.Map<Product>(createClientRequestModel);
        //    await _productRepository.InsertAsync(client);
        //    try
        //    {
        //        await _unitOfWork.CompleteAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public async Task<bool> DeleteAsync(int productId)
        //{
        //    _productRepository.Delete(productId);
        //    try
        //    {
        //        await _unitOfWork.CompleteAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //public bool Contains(int productId)
        //{
        //    return _productRepository.Contains(productId);
        //}

    }
}
