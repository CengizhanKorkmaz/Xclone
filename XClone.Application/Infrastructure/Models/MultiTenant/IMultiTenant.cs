namespace XClone.Application.Infrastructure.Models.MultiTenant;

public interface IMultiTenant
{
    string TenantId { get; set; }
}