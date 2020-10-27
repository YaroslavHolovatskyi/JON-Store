using AutoMapper;
using JON_Store.Api.Controllers.Models.Product;
using JON_Store.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JON_Store.Mappings
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<Product, GetSingleProductResponseModel>();
        }
    }
}
