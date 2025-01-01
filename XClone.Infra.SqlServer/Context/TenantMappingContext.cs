using Microsoft.EntityFrameworkCore;
using XClone.Domain.Entities;
using XClone.Infra.SqlServer.Configurations;

namespace XClone.Infra.SqlServer.Context;

public class TenantMappingContext(DbContextOptions<TenantMappingContext> options):DbContext(options)
{
    public DbSet<TenantMapping> TenantMappings { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TenantMappingConfiguration());
    }
    
}