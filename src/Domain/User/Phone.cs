namespace Domain.User;

public sealed class Phone : ValueObject
{
    private const string Pattern = @"^\d{9}$";
    public string Value { get; init; }

    private Phone(string value)
    {
        Value = value;
    }

    public static Result<Phone> Create(string number)
    {
        if (string.IsNullOrEmpty(number))
        {
            return DomainErrors.General.ValueIsRequired();
        }

        if (!Regex.IsMatch(number, Pattern))
        {
            return DomainErrors.User.InvalidPhoneNumber(number);
        }

        return new Phone(number);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}