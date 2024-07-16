using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.HasKey(x => x.Id).HasName("Id");
        builder.Property(x => x.Id).HasColumnName("Id").HasColumnOrder(1).IsRequired().ValueGeneratedOnAdd();

        builder.Property(x => x.Name).HasColumnName("Name").HasColumnOrder(2).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).HasColumnName("Email").HasColumnOrder(3).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Password).HasColumnName("Password").HasColumnOrder(4).IsRequired().HasMaxLength(20);
        builder.Property(x => x.JoinDate).HasColumnName("JoinDate").HasColumnOrder(5).IsRequired();

        builder.HasMany(x => x.Activities)
       .WithOne(x => x.User)
       .HasForeignKey(x => x.UserId);
    }
}
