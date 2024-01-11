namespace Domain.User;

public sealed class Email : ValueObject
{
    public string Value { get; init; }
    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return DomainErrors.General.ValueIsRequired();
        }

        if (!new EmailAddressAttribute().IsValid(email))
        {
            return DomainErrors.User.InvalidEmail(email);
        }

        return new Email(email);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}