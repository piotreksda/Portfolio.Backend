using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Dictionary.Entities.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("Languages");

        builder.HasKey(l => l.Id);
        
        builder.Property(l => l.Deleted).IsRequired().HasDefaultValue(false);
        
        builder.HasIndex(l => l.IsoCode)
            .IsUnique()
            .HasFilter("\"Deleted\" = false");

        builder.HasMany(l => l.Translations)
            .WithOne(t => t.Language)
            .HasForeignKey(t => t.LangId);
    }
}