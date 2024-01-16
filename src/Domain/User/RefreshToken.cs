namespace Domain.User;

public class RefreshToken : ValueObject
{
    public bool Revoked { get; init; }
    public string Value { get; init; }
    public TimeSpan Expiry { get; init; }

    private RefreshToken(string value, TimeSpan expiry, bool revoked)
    {
        Value = value;
        Revoked = revoked;
        Expiry = expiry;
    }

    public RefreshToken RevokeToken() => new(Value, Expiry, true);

    public static RefreshToken Generate()
    {
        var randomNumber = new byte[64];
        using var generator = RandomNumberGenerator.Create();
        generator.GetBytes(randomNumber);
        var token = Convert.ToBase64String(randomNumber);

        return new RefreshToken(token, TimeProvider.System.GetUtcNow().AddHours(3).TimeOfDay, false);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Revoked;
        yield return Expiry;
        yield return Value;
    }
}