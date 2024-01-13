namespace Domain.User;

public sealed class FirstName : ValueObject
{
    public string Value { get; init; }

    private FirstName(string value)
    {
        Value = value;
    }

    public static FirstName Create(string fistName)
    {
        if (string.IsNullOrEmpty(fistName))
        {
            throw new InvalidFirstNameException(fistName, "First name cannot be null or empty.");
        }

        if (fistName.Length is < 2 or > 50)
        {
            throw new InvalidFirstNameException(fistName, "First name length should be between 2 and 50 characters.");
        }

        if (!fistName.All(char.IsLetter))
        {
            throw new InvalidFirstNameException(fistName, "First name should contain only letters.");
        }

        return new FirstName(fistName);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}