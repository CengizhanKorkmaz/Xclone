using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XClone.Domain.Entities;

namespace XClone.Infra.SqlServer.Configurations;

public class TenantMappingConfiguration: BaseEntityConfiguration<TenantMapping>
{
    public new void Configure(EntityTypeBuilder<TenantMapping> builder)
    {
        builder.Property(x=>x.UserId).IsRequired();
        builder.Property(x=>x.TenantId).IsRequired();
        
        builder.HasOne(x => x.User)
            .WithOne(x=>x.TenantMapping)
            .HasForeignKey<TenantMapping>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.Configure(builder);
        
    }
}