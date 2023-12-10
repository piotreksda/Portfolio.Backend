using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UsersRoles");

        builder.HasKey(ur => ur.Id);
        builder.HasIndex(ur => new { ur.UserId, ur.RoleId });
        
        builder.HasOne(ur => ur.Role)
            .WithMany(r => r.UsersRoles) // Assuming Role has a collection of UserRoles
            .HasForeignKey(ur => ur.RoleId);

        builder.HasOne(ur => ur.User)
            .WithMany(u => u.UsersRoles) // Assuming User has a collection of UserRoles
            .HasForeignKey(ur => ur.UserId);
        
        
        builder.Property(ur => ur.CreatedAt).IsRequired();
        builder.Property(ur => ur.CreatedBy).IsRequired();
        builder.Property(ur => ur.ModifiedAt).IsRequired(false);
        builder.Property(ur => ur.ModifiedBy).IsRequired(false);
        builder.Property(ur => ur.Deleted).IsRequired().HasDefaultValue(false);
    }
}