using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Domain.Core.Domain.Auth.Entities.Configurations;

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
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(u => u.IpAddress)
            .IsRequired();
        builder.Property(u => u.Location)
            .IsRequired(false);

        builder.HasOne(lh => lh.User)
            .WithMany()
            .HasForeignKey(lh => lh.UserId)
            .HasConstraintName("FK_LoginHistory_UserId");
        
    }
}