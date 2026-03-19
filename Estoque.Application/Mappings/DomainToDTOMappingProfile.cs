using AutoMapper;
using Estoque.Domain.Entities;
using Estoque.Application.DTOs;

namespace Estoque.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}
