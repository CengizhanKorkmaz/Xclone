using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using XClone.Domain.Entities;

namespace XClone.Infra.SqlServer.Configurations;

public class AuditLogInterceptor:SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var entities = eventData.Context.ChangeTracker.Entries().ToList();
        var auditLogs = eventData.Context.ChangeTracker.Entries()
            .Where(i => i.Entity is not AuditLog)
            .Where(i => i.State == EntityState.Added || i.State == EntityState.Modified ||
                        i.State == EntityState.Deleted).ToList();



        var auditLogEntities = new List<AuditLog>();

        foreach (var item in auditLogs)
        {
            var log = new AuditLog()
            {
                TableName = item.Metadata.GetTableName(),
                Operation = item.State.ToString(),
                CreatedDate = DateTime.Now
            };

            if (item.State == EntityState.Modified)
            {
                log.OldValue = JsonSerializer.Serialize(item.OriginalValues.Properties.ToDictionary(p => p.Name, p => item.OriginalValues[p]));
                log.NewValue = JsonSerializer.Serialize(item.CurrentValues.Properties.ToDictionary(p => p.Name, p => item.CurrentValues[p]));
            }
            else if (item.State == EntityState.Added)
            {
                log.NewValue = JsonSerializer.Serialize(item.CurrentValues.Properties.ToDictionary(p => p.Name, p => item.CurrentValues[p]));
            }
            else if (item.State == EntityState.Deleted)
            {
                log.OldValue = JsonSerializer.Serialize(item.OriginalValues.Properties.ToDictionary(p => p.Name, p => item.OriginalValues[p]));
            }
            
            auditLogEntities.Add(log);
        }
        
        eventData.Context.Set<AuditLog>().AddRange(auditLogEntities);
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}