namespace Domain.User;

public sealed class Phone : ValueObject
{
    private const string Pattern = @"^\d{9}$";
    public string Value { get; init; }

    private Phone(string value)
    {
        Value = value;
    }

    public static Phone Create(string number)
    {
        if (string.IsNullOrEmpty(number))
        {
            throw new InvalidPhoneException(number, "Phone cannot be null or empty.");
        }

        if (!Regex.IsMatch(number, Pattern))
        {
            throw new InvalidPhoneException(number, "Invalid phone number format. It must be a 9-digit numeric value.");
        }

        return new Phone(number);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}