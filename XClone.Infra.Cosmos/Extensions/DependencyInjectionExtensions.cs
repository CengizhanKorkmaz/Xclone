using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.DependencyInjection;
using XClone.Application.Repositories;
using XClone.Application.Services;
using XClone.Infra.Cosmos.Repositories;
using XClone.Infra.Cosmos.Services;

namespace XClone.Infra.Cosmos.Extensions;

public static class DependencyInjectionExtensions
{

    public static IServiceCollection AddInfraCosmosServices(this IServiceCollection services, string cosmosConnString)
    {
        services.AddSingleton(sp =>
        {
            var builder = new CosmosClientBuilder(cosmosConnString)
                .WithApplicationName("XClone")
                .WithSerializerOptions(new CosmosSerializationOptions()
                {
                    Indented = true
                })
                .WithThrottlingRetryOptions(TimeSpan.FromSeconds(5), 10);
            return builder.Build();
        });


        services.AddScoped<ITenantCacheService,TenantCacheService>();
        services.AddScoped<ICacheRepository, CacheRepository>();

        return services;

    }
    
}