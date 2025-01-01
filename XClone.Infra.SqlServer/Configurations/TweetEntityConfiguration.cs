using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XClone.Domain.Entities;

namespace XClone.Infra.SqlServer.Configurations;

public sealed class TweetEntityConfiguration : BaseEntityConfiguration<Tweet>
{
    public new void Configure(EntityTypeBuilder<Tweet> builder)
    {
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.Content).IsRequired().HasMaxLength(280);
        
        
        builder.HasOne(x => x.User)
            .WithMany(x => x.Tweets)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.Configure(builder);
    }
    
}