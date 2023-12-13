using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Dictionary.Entities.Configurations;

public class TranslationConfiguration : IEntityTypeConfiguration<Translation>
{
    public void Configure(EntityTypeBuilder<Translation> builder)
    {
        builder.ToTable("Translations");

        builder.HasKey(t => t.Id);
        builder.HasIndex(t => new {t.LangId, t.TranslationKey})
            .IsUnique()
            .HasFilter("\"Deleted\" = false");
        
        builder.Property(t => t.CreatedAt).IsRequired();
        builder.Property(t => t.CreatedBy).IsRequired();
        builder.Property(t => t.ModifiedAt).IsRequired(false);
        builder.Property(t => t.ModifiedBy).IsRequired(false);
        builder.Property(t => t.Deleted).IsRequired().HasDefaultValue(false);

        builder.HasOne(t => t.TranslationType)
            .WithMany(tt => tt.Translations)
            .HasForeignKey(t => t.TranslationTypeId);

        builder.HasOne(t => t.Language)
            .WithMany(l => l.Translations)
            .HasForeignKey(t => t.LangId);
    }
}