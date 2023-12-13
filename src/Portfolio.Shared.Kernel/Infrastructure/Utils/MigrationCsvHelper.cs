using System.Text;

namespace Portfolio.Shared.Kernel.Infrastructure.Utils;

public class MigrationCsvHelper
{
    public static string GetCsvMigrationDataPath(string folderName, string fileName)
    {
        return
            $"..{Path.DirectorySeparatorChar}Portfolio.Migration{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}{folderName}{Path.DirectorySeparatorChar}{fileName}";
    }
    
    private const string Quote = "\"";
    private const string SemiColon = ";";
    private const string Comma = ",";

    public static string CsvToSql(string tableName, string migrationFolderName, string migrationCsvFileName,
        bool updateOnConflict = true)
    {
        string path = GetCsvMigrationDataPath(migrationFolderName, migrationCsvFileName);
        return CsvToSql(tableName, path, updateOnConflict);
    }
    public static string CsvToSql(string tableName, string filePath, bool updateOnConflict = true)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        var insertStatement = new StringBuilder();
        var updateStatement = new StringBuilder();

        using var reader = new StreamReader(filePath);
        bool isFirstRow = true;
        bool isFirstValueSet = true;
        int recordCount = 0;

        while (!reader.EndOfStream)
        {
            var line = FormatCSVLine(reader.ReadLine());
            var columns = line.Split(SemiColon);

            if (isFirstRow)
            {
                isFirstRow = false;
                AppendInsertStatement(insertStatement, tableName, columns);
                if (updateOnConflict)
                {
                    AppendUpdateStatement(updateStatement, columns);
                }
            }
            else
            {
                AppendValues(insertStatement, columns, ref isFirstValueSet);
                recordCount++;
            }
        }

        if (recordCount > 0)
        {
            insertStatement.Append(updateStatement);
            return insertStatement.ToString();
        }

        return string.Empty;
    }

    private static string FormatCSVLine(string line)
    {
        return Quote + line.Replace(Quote, "").Replace(SemiColon, Quote + SemiColon + Quote).Trim() + Quote;
    }

    private static void AppendInsertStatement(StringBuilder builder, string tableName, string[] columns)
    {
        builder.Append($"INSERT INTO \"{tableName}\" (");
        builder.Append(string.Join(Comma, columns));
        builder.Append(") VALUES ");
    }

    private static void AppendUpdateStatement(StringBuilder builder, string[] columns)
    {
        builder.Append($"ON CONFLICT({columns[0]}) DO UPDATE SET ");
        for (int i = 1; i < columns.Length; i++)
        {
            if (i != 1)
            {
                builder.Append(Comma);
            }
            builder.Append($"{columns[i]} = EXCLUDED.{columns[i]}");
        }
    }

    private static void AppendValues(StringBuilder builder, string[] columns, ref bool isFirstValueSet)
    {
        if (!isFirstValueSet)
        {
            builder.Append(Comma);
        }
        else
        {
            isFirstValueSet = false;
        }

        var formattedValues = columns.Select(col => "'" + col.Replace("'", "''").Replace(Quote, "").Replace("null", "''") + "'").ToArray();
        builder.Append("(" + string.Join(Comma, formattedValues) + ")");
    }
}