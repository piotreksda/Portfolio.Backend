using System;
using System.IO;
using System.Reflection;

namespace RazorTemplateEngine.Services;

public class FileToHtmlTool
{
    public static string ConvertToBase64Src(string filePath)
    {
        filePath = Path.Combine(GetAssemblyDirectory(), filePath);
        
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found.", filePath);
        }

        string mimeType = GetMimeType(filePath);

        byte[] fileBytes = File.ReadAllBytes(filePath);
        string base64String = Convert.ToBase64String(fileBytes);

        return $"data:{mimeType};base64,{base64String}";
    }

    private static string GetMimeType(string filePath)
    {
        string extension = Path.GetExtension(filePath).ToLowerInvariant();

        return extension switch
        {
            ".svg" => "image/svg+xml",
            ".png" => "image/png",
            ".jpg" => "image/jpeg",
            ".jpeg" => "image/jpeg",
            _ => throw new ArgumentException("Unsupported file type.", nameof(filePath)),
        };
    }
    
    private static string GetAssemblyDirectory()
    {
        string codeBase = Assembly.GetExecutingAssembly().Location;

        string directory = Path.GetDirectoryName(codeBase);

        return directory;
    }
}