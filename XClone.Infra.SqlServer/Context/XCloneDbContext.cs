using Microsoft.EntityFrameworkCore;
using XClone.Domain.Entities;
using XClone.Infra.SqlServer.Configurations;
using XCloneModels.Helpers;

namespace XClone.Infra.SqlServer.Context;

public class XCloneDbContext(DbContextOptions<XCloneDbContext> options,
    GetTenantIdDelegate getTenantIdDelegate,IServiceProvider serviceProvider
    ) : DbContext(options)
{
    public DbSet<Tweet> Tweets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Follow> Follows { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration<>).Assembly);
        var userId = getTenantIdDelegate(serviceProvider);
        //modelBuilder.Entity<User>().HasQueryFilter(x => x.Id == userId);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditLogInterceptor());
        base.OnConfiguring(optionsBuilder);
    }
}
