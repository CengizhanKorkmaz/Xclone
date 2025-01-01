using XClone.Application.Repositories;
using XClone.Application.Services;
using XClone.Infra.Cosmos.Models;

namespace XClone.Infra.Cosmos.Services;

internal class TenantCacheService(ICacheRepository cacheRepository):ITenantCacheService
{
    public async Task<T> GetCache<T>(string tenantId, string key)
    {
        var cacheModel = await cacheRepository.GetItemById<BaseCosmosModel<T>>(key, tenantId);
        return (cacheModel.Value is null ? default : cacheModel.Value)!;
    }

    public async Task SetCache<T>(string tenantId, string key, T value)
    {
        BaseCosmosModel<T> cacheModel = new()
        {
            Id = key,
            TenantId = tenantId,
            Value = value
        };
        
        await cacheRepository.UpSert(cacheModel, tenantId);
    }
}