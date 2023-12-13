using System.Text;

namespace Portfolio.Shared.Kernel.Infrastructure.Utils;

public class GeneralTools
{
    private static readonly string CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private static readonly Random Random = new Random();

    public static string GenerateRandomString(int length = 64)
    {
        var stringBuilder = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            int randomIndex = Random.Next(CharSet.Length);
            stringBuilder.Append(CharSet[randomIndex]);
        }

        return stringBuilder.ToString();
    }
}