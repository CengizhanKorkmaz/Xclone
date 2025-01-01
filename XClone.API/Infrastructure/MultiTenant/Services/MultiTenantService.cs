using XClone.Application.Services;

namespace WebApplication1.Infrastructure.MultiTenant.Services;

public interface IMultiTenantService
{
    Guid? GetUserId();
    string GetCurrentTenantId();
    string SetCurrentTenantId(string tenantId);
}
public class MultiTenantService:IMultiTenantService
{
    private string tenantId = "";
    private readonly ITenantMappingService _mappingService;

    public MultiTenantService(ITenantMappingService mappingService)
    {
        _mappingService = mappingService;
    }
    
    public string GetCurrentTenantId() => "";
    public string SetCurrentTenantId(string tenantId) => this.tenantId = tenantId;

    public Guid? GetUserId() => _mappingService.GetUserByTenantId(tenantId);
}