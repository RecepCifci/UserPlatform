using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using UserPlatform.Application.Dtos;
using UserPlatform.Application.Managers;
using UserPlatform.Application.Services;
using UserPlatform.Application.Validators;

namespace UserPlatform.Application;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserDto>, UserValidator>();
        services.AddScoped<IActivityManager, ActivityManager>();
        services.AddScoped<IValidator<ActivityDto>, ActivityValidator>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IActivityService, ActivityService>();
        return services;
    }

}
