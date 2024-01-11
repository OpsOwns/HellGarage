namespace Domain.User;

public sealed class HashedPassword : ValueObject
{
    public string Hash { get; init; }
    public string Salt { get; init; }

    public HashedPassword(string hash, string salt)
    {
        Hash = hash;
        Salt = salt;
    }

    public static Result<HashedPassword> Create(string hash, string salt)
    {
        if (string.IsNullOrWhiteSpace(hash))
        {
            return DomainErrors.General.ValueIsRequired();
        }

        if (string.IsNullOrWhiteSpace(salt))
        {
            return DomainErrors.General.ValueIsRequired();
        }

        return new HashedPassword(hash, salt);
    }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Hash;
        yield return Salt;
    }
}