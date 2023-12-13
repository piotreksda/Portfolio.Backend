using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Shared.Kernel.Domain.Dictionary.Entities.Configurations;

public class TranslationTypeConfiguration: IEntityTypeConfiguration<TranslationType>
{
    public void Configure(EntityTypeBuilder<TranslationType> builder)
    {
        builder.ToTable("TranslationTypes");

        builder.HasKey(tt => tt.Id);
        builder.HasIndex(tt => tt.Name)
            .IsUnique()
            .HasFilter("\"Deleted\" = false");
        
        builder.Property(tt => tt.Deleted).IsRequired().HasDefaultValue(false);

        builder.HasMany(tt => tt.Translations)
            .WithOne(t => t.TranslationType)
            .HasForeignKey(t => t.TranslationTypeId);
    }
}