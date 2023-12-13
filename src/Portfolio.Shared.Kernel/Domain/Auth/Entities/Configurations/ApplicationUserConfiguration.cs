using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id)
            .IsUnique();
        builder.HasIndex(u => u.UserName)
            .IsUnique()
            .HasDatabaseName("User_UserName");
        
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(64);
        builder.Property(u => u.NormalizedUserName).IsRequired().HasMaxLength(64);

        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("Email")
                .HasMaxLength(Email.MaxLen)
                .IsRequired(false);
            
            email.HasIndex(e => e.Value)
                .IsUnique()
                .HasDatabaseName("User_Email");
        });

        builder.OwnsOne(u => u.NormalizedEmail, normalizedEmail =>
        {
            normalizedEmail.Property(e => e.Value)
                .HasColumnName("NormalizedEmail")
                .HasMaxLength(Email.MaxLen)
                .IsRequired();
            
            normalizedEmail.HasIndex(u => u.Value)
                .IsUnique()
                .HasDatabaseName("User_NormalizedEmail");
        });
        
        builder.OwnsOne(u => u.PhoneNumber, phoneNumber =>
        {
            phoneNumber.Property(e => e.Value)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(PhoneNumber.MaxLen)
                .IsRequired(false);

            phoneNumber.HasIndex(u => u.Value)
                .IsUnique()
                .HasDatabaseName("User_PhoneNumber")
                .HasFilter("\"PhoneNumber\" IS NOT NULL");;
        });
        
        builder.Property(u => u.EmailConfirmed).IsRequired().HasDefaultValue(false);
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.SecurityStamp).IsRequired().HasDefaultValue(new Guid());
        
        builder.Property(u => u.PhoneNumberConfirmed).IsRequired().HasDefaultValue(false);
        builder.Property(u => u.TwoFactorEnabled).IsRequired().HasDefaultValue(false);
        builder.Property(u => u.LockoutEnd).IsRequired(false);
        builder.Property(u => u.AccessFailedCount).IsRequired().HasDefaultValue(0);

        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.CreatedBy).IsRequired();
        builder.Property(u => u.ModifiedAt).IsRequired(false);
        builder.Property(u => u.ModifiedBy).IsRequired(false);
        builder.Property(u => u.Deleted).IsRequired().HasDefaultValue(false);
        
        builder.HasMany(u => u.UsersRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);
        
        builder.HasMany(u => u.RefreshTokens)
            .WithOne(rf => rf.User)
            .HasForeignKey(rf => rf.UserId);
        
        builder.HasMany(u => u.LoginHistories)
            .WithOne(rf => rf.User)
            .HasForeignKey(rf => rf.UserId);
        
        builder.HasMany(u => u.ActionTokens)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);
    }
}