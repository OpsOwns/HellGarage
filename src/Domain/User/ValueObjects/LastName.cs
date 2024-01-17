namespace Domain.User.ValueObjects;

public sealed class LastName : ValueObject
{
    public string Value { get; init; }

    private LastName(string value)
    {
        Value = value;
    }

    public static LastName Create(string lastName)
    {
        if (string.IsNullOrEmpty(lastName)) throw new InvalidLastNameException(lastName, "Last name cannot be null or empty.");

        if (lastName.Length is < 2 or > 50) throw new InvalidLastNameException(lastName, "Last name length should be between 2 and 50 characters.");

        if (!lastName.All(char.IsLetter)) throw new InvalidLastNameException(lastName, "Last name should contain only letters.");

        return new LastName(lastName);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}