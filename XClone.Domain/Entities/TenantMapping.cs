namespace XClone.Domain.Entities;

public class TenantMapping : BaseEntity
{
    public Guid UserId { get; set; }
    public string TenantId { get; set; }
    public User User { get; set; }
}