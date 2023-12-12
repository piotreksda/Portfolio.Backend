using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.Configurations;

public class LoginHistoryConfiguration : IEntityTypeConfiguration<LoginHistory>
{
    public void Configure(EntityTypeBuilder<LoginHistory> builder)
    {
        builder.ToTable("LoginHistory");

        builder.HasKey(lh => lh.Id);
        builder.HasIndex(lh => lh.UserId);
        
        builder.Property(u => u.Deleted).IsRequired().HasDefaultValue(false);
        builder.Property(u => u.Date)
            .IsRequired()
            .HasDefaultValueSql("timezone('utc', now())");

        builder.Property(u => u.IpAddress)
            .IsRequired();
        builder.Property(u => u.Location)
            .IsRequired(false);

        builder.HasOne(lh => lh.User)
            .WithMany(u => u.LoginHistories)
            .HasForeignKey(lh => lh.UserId);
    }
}