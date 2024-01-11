namespace Domain.User;

public sealed class Password : ValueObject
{
    public string Value { get; init; }
    private const string PasswordComplexityExpression = @"^(?=.*[a-zA-Z])(?=.*\d.*\d)(?=.*[!@#$%^&*~/""()_=+\[\]\\|,.?-]).*$";
    private const int MinLength = 8;
    private const int MaxLength = 50;

    private Password(string value)
    {
        Value = value;
    }

    public static Result<Password> Create(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return DomainErrors.General.ValueIsRequired();

        switch (password.Length)
        {
            case < MinLength:
                return DomainErrors.General.ValueTooLong(MinLength);
            case > MaxLength:
                return DomainErrors.General.ValueTooLong(MaxLength);
        }

        if (!Regex.IsMatch(password, PasswordComplexityExpression))
            return DomainErrors.User.PasswordBreakComplexityRules();

        return new Password(password);
    }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public HashedPassword Hash()
    {
        string salt = HashCalculator.GenerateSalt();
        string hash = HashCalculator.Calculate(Value, salt);

        return new HashedPassword(hash, salt);
    }


    public bool IsMatch(HashedPassword hashedPassword)
    {
        string hash = HashCalculator.Calculate(Value, hashedPassword.Salt);

        return hashedPassword.Hash == hash;
    }
}

internal static class HashCalculator
{
    public static string Calculate(string password, string salt)
    {
        var passwordBytes = Encoding.ASCII.GetBytes(password);
        var saltBytes = Convert.FromBase64String(salt);

        var buffer = new byte[passwordBytes.Length + saltBytes.Length];
        saltBytes.CopyTo(buffer, 0);
        passwordBytes.CopyTo(buffer, saltBytes.Length);

        var hashBuffer = SHA256.HashData(buffer);

        return Convert.ToBase64String(hashBuffer);
    }


    public static string GenerateSalt()
    {
        Random rnd = new();
        var salt = new byte[32];
        rnd.NextBytes(salt);

        return Convert.ToBase64String(salt);
    }
}