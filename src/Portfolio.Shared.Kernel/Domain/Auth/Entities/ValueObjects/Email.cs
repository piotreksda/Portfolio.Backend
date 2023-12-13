using System.Text.RegularExpressions;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.CoreExceptions;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Domain.Auth.Entities.ValueObjects;

public class Email : ValueObject
{
    public static int MinLen { get; } = 3;
    public static int MaxLen { get; } = 64;
    public static Regex ValidationRegex { get; } = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");

    public string Value { get; init; }
    
    public Email(string value)
    {
        Value = value;
        Validate();
    }
    
    public static implicit operator Email(string value)
    {
        return new Email(value);
    }

    public static implicit operator string(Email email)
    {
        return email.Value;
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

    public Email GetNormalizedEmail()
    {
        return new Email(Value.ToUpper());
    }
}