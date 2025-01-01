namespace XClone.Application.Services;

public interface ITenantCacheService
{
    Task<T> GetCache<T>(string tenantId,string key);
    Task SetCache<T>(string tenantId,string key,T value);
}