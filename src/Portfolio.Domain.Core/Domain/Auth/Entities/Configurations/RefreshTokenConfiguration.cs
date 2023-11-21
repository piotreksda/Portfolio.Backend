using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Domain.Core.Domain.Auth.Entities.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");

        builder.HasKey(rt => rt.Id);
        builder.HasIndex(rt => rt.Id);
        
        builder.Property(rt => rt.CreatedAt).IsRequired();
        builder.Property(rt => rt.CreatedBy).IsRequired();
        builder.Property(rt => rt.ModifiedAt).IsRequired(false);
        builder.Property(rt => rt.ModifiedBy).IsRequired(false);
        builder.Property(rt => rt.Deleted).IsRequired().HasDefaultValue(false);

        builder.HasOne(rt => rt.User)
            .WithMany()
            .HasForeignKey(rf => rf.UserId)
            .HasConstraintName("FK_RefreshToken_UserId");
            
    }
}