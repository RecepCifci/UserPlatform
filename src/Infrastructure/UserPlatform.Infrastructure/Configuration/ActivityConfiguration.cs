using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Infrastructure.Configuration;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable(nameof(Activity));
        builder.HasKey(x => x.Id).HasName("Id");
        builder.Property(x => x.Id).HasColumnName("Id").HasColumnOrder(1).IsRequired().ValueGeneratedOnAdd();

        builder.Property(x => x.Description).HasColumnName("Description").HasColumnOrder(2).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Type).HasColumnName("Type").HasColumnOrder(3).IsRequired();
        builder.Property(x => x.Date).HasColumnName("Date").HasColumnOrder(5).IsRequired();

        builder.HasOne(x => x.User)
       .WithMany(x => x.Activities)
       .HasForeignKey(x => x.UserId);
    }
}
