using Bnn.Services.Bananas;
using Microsoft.Extensions.DependencyInjection;

namespace Bnn.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBananasService, BananasService>();
        
        return services;
    }
}