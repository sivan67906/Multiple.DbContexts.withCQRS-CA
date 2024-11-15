using Domain.DbContexts.Domain.Entities;
using Domain.DbContexts.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Multiple.DbContexts.Infrastructure.Data;
using Multiple.DbContexts.Infrastructure.Repositories;
using Multiple.DbContexts.Library.DependencyInjection;

namespace Multiple.DbContexts.Infrastructure.DependentInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add database connectivity
        // Add authentication scheme
        SharedServiceContainer.AddSharedServices<DomainMultipleDbContext>(
            services, configuration, configuration["MySerilog:FileName"]!);

        // Create DI
        services.AddScoped<IRepository<Product>, Repository<Product>>();
        services.AddScoped<IRepository<Order>, Repository<Order>>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructurePolicy(this IApplicationBuilder app)
    {
        // Use global exception
        // Register middleware to block all outsiders API calls
        //app.UseMiddleware<ListenOnlyToGatewayMiddleware>();
        SharedServiceContainer.UseSharedPolicies(app);

        return app;
    }
}
