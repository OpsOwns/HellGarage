namespace Domain.User.ValueObjects;

public sealed class HashedPassword : ValueObject
{
    public string Hash { get; init; }
    public string Salt { get; init; }

    private HashedPassword(string hash, string salt)
    {
        Hash = hash;
        Salt = salt;
    }

    public static HashedPassword Create(string hash, string salt)
    {
        if (string.IsNullOrWhiteSpace(hash)) throw new EmptyHashException();

        if (string.IsNullOrWhiteSpace(salt)) throw new EmptySaltException();

        return new HashedPassword(hash, salt);
    }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Hash;
        yield return Salt;
    }
}