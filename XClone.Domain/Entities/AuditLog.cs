namespace XClone.Domain.Entities;

public class AuditLog : BaseEntity
{
    public Guid UserId { get; set; }
    public string TableName { get; set; }
    public string Operation { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    
}