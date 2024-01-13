namespace Domain.User.Exceptions;

internal class InvalidEmailException(string email) : CustomException($"State is invalid: '{email}'.")
{
    public string Email { get; } = email;
}