namespace Domain.User;

public sealed class LastName : ValueObject
{
    public string Value { get; init; }

    private LastName(string value)
    {
        Value = value;
    }

    public static Result<LastName> Create(string lastName)
    {
        if (string.IsNullOrEmpty(lastName))
        {
            return DomainErrors.General.ValueIsRequired();
        }

        if (lastName.Length is < 2 or > 50)
        {
            return DomainErrors.User.OutOfRangeCharacter("Last name");
        }

        if (!lastName.All(char.IsLetter))
        {
            return DomainErrors.User.InvalidCharacters("Last name");
        }

        return new LastName(lastName);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}