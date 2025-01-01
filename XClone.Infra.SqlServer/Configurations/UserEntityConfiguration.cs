using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XClone.Domain.Entities;

namespace XClone.Infra.SqlServer.Configurations;

public sealed class UserEntityConfiguration : BaseEntityConfiguration<User>
{
    public new void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.EmailAddress).IsRequired().HasMaxLength(50);
        
        base.Configure(builder);
    }
}