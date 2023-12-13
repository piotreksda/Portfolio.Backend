using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Core.Entities.Configurations;

public class ActionTokenConfiguration : IEntityTypeConfiguration<ActionToken>
{
    public void Configure(EntityTypeBuilder<ActionToken> builder)
    {
        builder.ToTable("ActionTokens");

        builder.HasKey(at => at.Id);
        builder.HasIndex(ur => new { ur.UserId, ur.Token })
            .IsUnique();
        
        builder.HasOne(at => at.User)
            .WithMany(r => r.ActionTokens) 
            .HasForeignKey(at => at.UserId);

        builder.Property(at => at.Used).IsRequired().HasDefaultValue(false);
        
        builder.Property(at => at.CreatedAt).IsRequired();
        builder.Property(at => at.CreatedBy).IsRequired();
        builder.Property(at => at.ModifiedAt).IsRequired(false);
        builder.Property(at => at.ModifiedBy).IsRequired(false);
        builder.Property(at => at.Deleted).IsRequired().HasDefaultValue(false);
    }
}