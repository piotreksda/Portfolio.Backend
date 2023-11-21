using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Domain.Core.Domain.Auth.Entities.Configurations;

public class RolePermissionSetConfiguration : IEntityTypeConfiguration<RolePermissionSet>
{
    public void Configure(EntityTypeBuilder<RolePermissionSet> builder)
    {
        builder.ToTable("RolesPermissionSets");

        builder.HasKey(rsp => rsp.Id);
        builder.HasIndex(rsp => new { rsp.PermissionSetId, rsp.RoleId });
        
        builder.HasOne(rsp => rsp.PermissionSet)
            .WithMany()
            .HasForeignKey(rsp => rsp.PermissionSetId)
            .HasConstraintName("FK_RolePermissionSet_PermissionSetId");

        builder.HasOne(rsp => rsp.Role)
            .WithMany()
            .HasForeignKey(rsp => rsp.RoleId)
            .HasConstraintName("FK_RolePermissionSet_RoleId");
    
        
        builder.Property(rsp => rsp.CreatedAt).IsRequired();
        builder.Property(rsp => rsp.CreatedBy).IsRequired();
        builder.Property(rsp => rsp.ModifiedAt).IsRequired(false);
        builder.Property(rsp => rsp.ModifiedBy).IsRequired(false);
        builder.Property(rsp => rsp.Deleted).IsRequired().HasDefaultValue(false);
    }
}