using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XClone.Domain.Entities;

namespace XClone.Infra.SqlServer.Configurations;

public sealed class LikeEntityConfiguration : BaseEntityConfiguration<Like>
{
    public new void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.TweetId).IsRequired();
        builder.HasOne(x => x.User)
            .WithMany(x => x.Likes)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Tweet)
            .WithMany(x => x.Likes)
            .HasForeignKey(x => x.TweetId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.Configure(builder);
    }
}