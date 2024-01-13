namespace Domain.User;

public sealed class Email : ValueObject
{
    public string Value { get; init; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new InvalidEmailException(email);
        }

        if (!new EmailAddressAttribute().IsValid(email))
        {
            throw new InvalidEmailException(email);
        }

        return new Email(email);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}