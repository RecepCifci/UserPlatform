using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserPlatform.Application.Services;

namespace UserPlatform.Application;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IActivityService, ActivityService>();
        return services;
    }

}
