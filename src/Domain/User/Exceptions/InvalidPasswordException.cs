namespace Domain.User.Exceptions;

internal class InvalidPasswordException(string password, string reason) : Exception($"Invalid password '{password}'. {reason}")
{
    public string Password { get; } = password;
    public string Reason { get; } = reason;
}