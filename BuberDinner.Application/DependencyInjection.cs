using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Services.Commands.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        // services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return services;
    }
}
