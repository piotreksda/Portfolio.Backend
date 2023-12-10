using System.Reflection;

namespace Portfolio.Shared.Kernel.Infrastructure.Utils;

public static class TranslationsKeysTools
{
    public static List<string> GetListOfKeys(Type T) 
    {
        return T
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(field => field.FieldType == typeof(string))
            .Select(field => field.GetValue(null) as string)
            .ToList()!;
    }
}