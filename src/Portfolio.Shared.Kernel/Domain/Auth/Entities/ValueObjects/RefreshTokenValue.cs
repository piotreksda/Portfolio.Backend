using System.Security.Cryptography;
using System.Text;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;

public class RefreshTokenValue : ValueObject
{
    private RefreshTokenValue()
    {
        
    }

    public RefreshTokenValue(byte[] value)
    {
        Value = value;
    }
    public byte[] Value { get; private set; }
    public override IEnumerable<object> GetAtomicValues()
    {
        foreach (var byteValue in Value)
        {
            yield return byteValue;
        }
    }

    public static RefreshTokenValue GenerateRefreshTokenValue()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        // Use a cryptographic random number generator
        using (var rng = new RNGCryptoServiceProvider())
        {
            var stringChars = new char[64];
            var charBuffer = new byte[sizeof(uint)];

            for (int i = 0; i < stringChars.Length; i++)
            {
                rng.GetBytes(charBuffer);
                uint num = BitConverter.ToUInt32(charBuffer, 0);
                stringChars[i] = chars[(int)(num % chars.Length)];
            }

            // Convert the random string to a byte array
            string randomString = new string(stringChars);
            return new RefreshTokenValue(Encoding.UTF8.GetBytes(randomString));
        }
    }
    
    public static string ConvertToString(byte[] byteArray)
    {
        return Encoding.UTF8.GetString(byteArray);
    }
}