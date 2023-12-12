using Microsoft.EntityFrameworkCore.Migrations;
using Portfolio.Shared.Kernel.Infrastructure.Utils;

#nullable disable

namespace Portfolio.Shared.Kernel.Migrations
{
    /// <inheritdoc />
    public partial class Portfolio3SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationCsvHelper.CsvToSql("Languages", "3", "Languages.csv"));
            migrationBuilder.Sql(MigrationCsvHelper.CsvToSql("TranslationTypes", "3", "TranslationTypes.csv"));
            migrationBuilder.Sql(MigrationCsvHelper.CsvToSql("Translations", "3", "Translations.csv", false));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
