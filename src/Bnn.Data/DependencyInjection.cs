using Bnn.Data.Database;
using Bnn.Data.Migrations;
using Bnn.Data.Repositories;
using Bnn.Data.Repositories.Caching;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bnn.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDbConnectionFactory>(_ =>
            new DbConnectionFactory(configuration["ConnectionStrings:DefaultConnection"]!));
        
        services.AddFluentMigratorCore()
            .ConfigureRunner(config => config.AddPostgres()
                .WithGlobalConnectionString(configuration["ConnectionStrings:DefaultConnection"])
                .ScanIn(typeof(InitialMigration).Assembly).For.Migrations())
            .AddLogging(config => config.AddFluentMigratorConsole());
        
        services.AddScoped<IBananasRepository, BananasRepository>();
        services.Decorate<IBananasRepository, BananasCachedRepository>();
        
        services.AddLazyCache();
        
        return services;
    }
}