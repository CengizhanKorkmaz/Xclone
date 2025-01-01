namespace XClone.Application.Services;

public interface ITenantMappingService
{
    Guid? GetUserByTenantId(string tenantId);
}