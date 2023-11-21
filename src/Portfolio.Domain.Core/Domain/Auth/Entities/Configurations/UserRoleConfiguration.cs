using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Domain.Core.Domain.Auth.Entities.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UsersRoles");

        builder.HasKey(ur => ur.Id);
        builder.HasIndex(ur => new { ur.UserId, ur.RoleId });
        
        builder.HasOne(ur => ur.User)
            .WithMany()
            .HasForeignKey(ur => ur.RoleId)
            .HasConstraintName("FK_UserRole_RoleId");

        builder.HasOne(ur => ur.Role)
            .WithMany()
            .HasForeignKey(ur => ur.UserId)
            .HasConstraintName("FK_UserRole_UserId");
    
        
        builder.Property(ur => ur.CreatedAt).IsRequired();
        builder.Property(ur => ur.CreatedBy).IsRequired();
        builder.Property(ur => ur.ModifiedAt).IsRequired(false);
        builder.Property(ur => ur.ModifiedBy).IsRequired(false);
        builder.Property(ur => ur.Deleted).IsRequired().HasDefaultValue(false);
    }
}