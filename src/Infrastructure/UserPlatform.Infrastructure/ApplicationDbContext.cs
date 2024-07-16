using Microsoft.EntityFrameworkCore;
using UserPlatform.Domain.Entities;
using UserPlatform.Infrastructure.Configuration;

namespace UserPlatform.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ActivityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
