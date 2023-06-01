using System.Reflection;
using GenericApplication.Features.Requests.Commands;
using GenericApplication.Features.Requests.Queries;
using GenericPersistence;
using GenericPersistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GenericApplication;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // services.AddMediatR(Assembly.GetExecutingAssembly());
        // services.AddMediatR(typeof(GetGuitarQuery).GetTypeInfo().Assembly);
        // services.AddMediatR(typeof(CreateGuitarCommand).GetTypeInfo().Assembly);
        // services.AddScoped(typeof(IGuitarRepository), typeof(GuitarRepository));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGuitarRepository, GuitarRepository>();
        return services;
    }
}