using AutoMapper;
using MonolithicBase.Contract.Abstractions.Shared;
using MonolithicBase.Contract.Services.V1.Product;
using MonolithicBase.Domain.Entities;

namespace MonolithicBase.Application.Mapper;
public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        // V1
        CreateMap<Product, Response.ProductResponse>().ReverseMap();
        CreateMap<PagedResult<Product>, PagedResult<Response.ProductResponse>>().ReverseMap();

        // V2
        //CreateMap<Product, Contract.Services.V2.Product.Response.ProductResponse>().ReverseMap();
    }
}
