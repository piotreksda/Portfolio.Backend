using System.Text.RegularExpressions;
using Portfolio.Domain.Core.Domain.Core.Exceptions.CoreExceptions;
using Portfolio.Domain.Core.Domain.Core.Primitives;

namespace Portfolio.Domain.Core.Domain.Auth.Entities.ValueObjects;

public class PhoneNumber : ValueObject
{
    public static int MaxLen { get; } = 64;
    public static Regex ValidationRegex { get; } = new Regex("");
    
    public string Value { get; init; }

    public PhoneNumber(string value)
    {
        Value = value;
        Validate();
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    private void Validate()
    {
        if (!ValidationRegex.IsMatch(Value))
        {
            throw new ValidationException();
        }
    }
}