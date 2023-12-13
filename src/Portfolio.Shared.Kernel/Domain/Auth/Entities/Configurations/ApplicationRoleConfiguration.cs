using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.Configurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(r => r.Id);
        builder.HasIndex(r => r.Id);
        builder.HasIndex(r => r.Name)
            .IsUnique();
        
        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        
        builder.Property(r => r.CreatedAt).IsRequired();
        builder.Property(r => r.CreatedBy).IsRequired();
        builder.Property(r => r.ModifiedAt).IsRequired(false);
        builder.Property(r => r.ModifiedBy).IsRequired(false);
        builder.Property(r => r.Deleted).IsRequired().HasDefaultValue(false);
        
        builder.HasMany(r => r.UsersRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId);
    }
}