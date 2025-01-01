using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XClone.Domain.Entities;

namespace XClone.Infra.SqlServer.Configurations;

public sealed class FollowEntityConfiguration : BaseEntityConfiguration<Follow>
{
    public new void Configure(EntityTypeBuilder<Follow> builder)
    {
        builder.Property(x => x.FollowerUserId).IsRequired();
        builder.Property(x => x.FollowingUserId).IsRequired();
        builder.HasOne(x => x.FollowerUser)
            .WithMany(x => x.Followers)
            .HasForeignKey(x => x.FollowerUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.FollowingUser)
            .WithMany(x => x.Followings)
            .HasForeignKey(x => x.FollowingUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.Configure(builder);
    }
    
}