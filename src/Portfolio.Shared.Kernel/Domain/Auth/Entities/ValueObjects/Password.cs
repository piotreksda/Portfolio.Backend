using System.Text;
using System.Text.RegularExpressions;
using Konscious.Security.Cryptography;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;

public class Password : ValueObject
{
    public static int MinLen { get; } = 8;
    public static int MaxLen { get; } = 32;
    public static Regex ValidationRegex { get; } = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
    
    public string Value { get; init; }

    public Password(string value)
    {
        Value = value;
        Validate();
    }
    
    public static implicit operator Password(string value)
    {
        return new Password(value);
    }

    public static implicit operator string(Password password)
    {
        return password.Value;
    }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    private void Validate()
    {
        if (Value.Length > MaxLen || Value.Length < MinLen)
        {
            throw new ValidationException();
        }

        if (!ValidationRegex.IsMatch(Value))
        {
            throw new ValidationException();
        }
    }

    public static byte[] HashPassword(Password password)
    {
        // Generate a random salt
        byte[] salt = new byte[16];
        new Random().NextBytes(salt);

        // Create a new instance of Argon2
        using Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = 8; // Number of threads
        argon2.MemorySize = 65536;      // Amount of memory (in KB)
        argon2.Iterations = 4;          // Number of iterations

        // Get the hash as byte array
        byte[] hash = argon2.GetBytes(16);

        // Combine the salt and hash bytes for storage
        byte[] hashBytes = new byte[salt.Length + hash.Length];
        Array.Copy(salt, 0, hashBytes, 0, salt.Length);
        Array.Copy(hash, 0, hashBytes, salt.Length, hash.Length);

        // Convert to base64 for storage
        return hashBytes;
    }

    public static bool VerifyPassword(string password, byte[] hashedPassword)
    {
        byte[] hashBytes = hashedPassword;
        
        // Extract the salt
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, salt.Length);
        
        // Extract the hash
        byte[] hash = new byte[hashBytes.Length - salt.Length];
        Array.Copy(hashBytes, salt.Length, hash, 0, hash.Length);

        // Hash the password with the extracted salt and compare
        using Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = 8;
        argon2.MemorySize = 65536;
        argon2.Iterations = 4;

        byte[] newHash = argon2.GetBytes(hash.Length);
        return CompareByteArrays(hash, newHash);
    }

    private static bool CompareByteArrays(byte[] array1, byte[] array2)
    {
        if (array1.Length != array2.Length)
            return false;

        for (int i = 0; i < array1.Length; i++)
            if (array1[i] != array2[i])
                return false;

        return true;
    }
    
    
}