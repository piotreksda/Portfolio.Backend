using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.Configurations;

public class PermissionSetConfiguration : IEntityTypeConfiguration<PermissionSet>
{
    public void Configure(EntityTypeBuilder<PermissionSet> builder)
    {
        builder.ToTable("PermissionSets");

        builder.HasKey(ps => ps.Id);
        builder.HasIndex(ps => ps.Id);
        builder.HasIndex(ps => ps.Name)
            .IsUnique();
        
        builder.Property(ps => ps.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        
        builder.Property(ps => ps.CreatedAt).IsRequired();
        builder.Property(ps => ps.CreatedBy).IsRequired();
        builder.Property(ps => ps.ModifiedAt).IsRequired(false);
        builder.Property(ps => ps.ModifiedBy).IsRequired(false);
        builder.Property(ps => ps.Deleted).IsRequired().HasDefaultValue(false);

        builder.HasMany(ps => ps.PermissionPermissionSet)
            .WithOne(pps => pps.PermissionSet)
            .HasForeignKey(pps => pps.PermissionSetId);
        // .HasConstraintName("FK_PermissionSet_PermissionSetId");
    }
}