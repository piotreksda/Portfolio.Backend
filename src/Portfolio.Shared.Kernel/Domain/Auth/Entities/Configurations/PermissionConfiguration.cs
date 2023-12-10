using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");

        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Name)
            .IsUnique();
        
        builder.Property(r => r.CreatedAt).IsRequired();
        builder.Property(r => r.CreatedBy).IsRequired();
        builder.Property(r => r.ModifiedAt).IsRequired(false);
        builder.Property(r => r.ModifiedBy).IsRequired(false);
        builder.Property(r => r.Deleted).IsRequired().HasDefaultValue(false);

        builder.HasMany(p => p.PermissionPermissionSet)
            .WithOne(pps => pps.Permission)
            .HasForeignKey(pps => pps.PermissionId);
    }
}