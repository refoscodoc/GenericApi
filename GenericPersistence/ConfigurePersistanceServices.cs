using System.Reflection;
using GenericPersistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenericPersistence;

public static class ConfigurePersistenceServices
{
    public static IServiceCollection PersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        services.AddDbContext<GenericDbContext>(o =>
            o.UseMySql(configuration["ConnectionString"], serverVersion));
        return services;
    }
}