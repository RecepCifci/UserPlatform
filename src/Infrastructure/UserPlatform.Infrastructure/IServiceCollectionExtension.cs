using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UserPlatform.Infrastructure;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), opt => { opt.EnableRetryOnFailure(); });

        }, serviceLifetime);

        return services;
    }
}
