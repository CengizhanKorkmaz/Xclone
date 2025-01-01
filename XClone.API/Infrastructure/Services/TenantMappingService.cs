using XClone.Application.Services;
using XClone.Infra.SqlServer.Context;

namespace WebApplication1.Infrastructure.Services;

public class TenantMappingService : ITenantMappingService
{
    private TenantMappingContext _context;
    private readonly IServiceProvider _serviceProvider;
    private Dictionary<string, Guid> map;

    public TenantMappingService(IServiceProvider serviceProvider)
    {
     
        _serviceProvider = serviceProvider;
        LoadMap();

    }

    public Guid? GetUserByTenantId(string tenantId)
    {
        return map.TryGetValue(tenantId, out var userId) ? userId : null;
    }

    private void LoadMap()
    {
        using var scope = _serviceProvider.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<TenantMappingContext>();
        map = _context.TenantMappings.ToDictionary(x => x.TenantId, i => i.UserId);
    }
}