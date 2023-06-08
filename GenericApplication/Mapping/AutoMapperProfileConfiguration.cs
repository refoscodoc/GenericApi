using AutoMapper;
using GenericAPI.Dtos;
using GenericAPI.Models;
using GenericDomain.Models;

namespace GenericApplication.Mapping;

public class AutoMapperProfileConfiguration : Profile
{
    public AutoMapperProfileConfiguration()
    {
        CreateMap<GuitarModel, GuitarDto>();
        CreateMap<SellerModel, SellerDto>();
    }
}