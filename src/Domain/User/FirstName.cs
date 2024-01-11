namespace Domain.User;

public sealed class FirstName : ValueObject
{
    public string Value { get; init; }
    private FirstName(string value)
    {
        Value = value;
    }

    public static Result<FirstName> Create(string fistName)
    {
        if (string.IsNullOrEmpty(fistName))
        {
            return DomainErrors.General.ValueIsRequired();
        }

        if (fistName.Length is < 2 or > 50)
        {
            return DomainErrors.User.OutOfRangeCharacter("First name");
        }

        if (!fistName.All(char.IsLetter))
        {
            return DomainErrors.User.InvalidCharacters("First name");
        }

        return new FirstName(fistName);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}