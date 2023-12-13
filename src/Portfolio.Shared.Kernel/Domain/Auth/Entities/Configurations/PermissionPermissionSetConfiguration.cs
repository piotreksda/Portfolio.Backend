using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.Configurations;

public class PermissionPermissionSetConfiguration : IEntityTypeConfiguration<PermissionPermissionSet>
{
    public void Configure(EntityTypeBuilder<PermissionPermissionSet> builder)
    {
        builder.ToTable("PermissionsPermissionSets");

        builder.HasKey(pps => pps.Id);
        builder.HasIndex(pps => new { pps.PermissionId, pps.PermissionSetId });
        
        builder.HasOne(pps => pps.Permission)
            .WithMany(p => p.PermissionPermissionSet)
            .HasForeignKey(pps => pps.PermissionId);

        builder.HasOne(pps => pps.PermissionSet)
            .WithMany(ps => ps.PermissionPermissionSet)
            .HasForeignKey(pps => pps.PermissionSetId);
        
        builder.Property(pps => pps.CreatedAt).IsRequired();
        builder.Property(pps => pps.CreatedBy).IsRequired();
        builder.Property(pps => pps.ModifiedAt).IsRequired(false);
        builder.Property(pps => pps.ModifiedBy).IsRequired(false);
        builder.Property(pps => pps.Deleted).IsRequired().HasDefaultValue(false);
    }
}