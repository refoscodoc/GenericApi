using AutoMapper;
using GenericAPI.Dtos;
using GenericAPI.Models;
using GenericApplication.Mapping;
using GenericDomain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GenericApplication;

public static class ApplicationModelsMappingRegistration
{
    public static void InitializeAutomapper(this IServiceCollection services)
    {
        var configuration = new MapperConfiguration(cfg => 
        {
            // cfg.CreateMap<GuitarModel, GuitarDto>();
            // cfg.CreateMap<SellerModel, SellerDto>();
            cfg.AddProfile(new AutoMapperProfileConfiguration());
        });
// only during development, validate your mappings; remove it before release
#if DEBUG
        configuration.AssertConfigurationIsValid();
#endif
// use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
        var mapper = configuration.CreateMapper();

        services.AddSingleton(mapper);
    }
    
}