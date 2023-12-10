using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.Configurations;

public class RolePermissionSetConfiguration : IEntityTypeConfiguration<RolePermissionSet>
{
    public void Configure(EntityTypeBuilder<RolePermissionSet> builder)
    {
        builder.ToTable("RolesPermissionSets");

        builder.HasKey(rsp => rsp.Id);
        builder.HasIndex(rsp => new { rsp.PermissionSetId, rsp.RoleId });

        builder.HasOne(rsp => rsp.PermissionSet)
            .WithMany(ps => ps.RolePermissionSets)
            .HasForeignKey(rsp => rsp.PermissionSetId);

            builder.HasOne(rsp => rsp.Role)
                .WithMany(r => r.RolesPermissionSets)
                .HasForeignKey(rsp => rsp.RoleId);
        
        builder.Property(rsp => rsp.CreatedAt).IsRequired();
        builder.Property(rsp => rsp.CreatedBy).IsRequired();
        builder.Property(rsp => rsp.ModifiedAt).IsRequired(false);
        builder.Property(rsp => rsp.ModifiedBy).IsRequired(false);
        builder.Property(rsp => rsp.Deleted).IsRequired().HasDefaultValue(false);
    }
}