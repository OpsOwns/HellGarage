namespace Shared;

public sealed class Error(string code, string message) : ValueObject
{
    public string Code { get; } = code;
    public string Message { get; } = message;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Message;
    }

    internal static Error None => new(string.Empty, string.Empty);
    
    public static implicit operator string(Error error) => error.Code;
}