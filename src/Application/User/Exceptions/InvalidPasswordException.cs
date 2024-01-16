namespace Application.User.Exceptions;

internal sealed class InvalidPasswordException(Password password) : CustomException($"The provided password '{password.Value}' is invalid");