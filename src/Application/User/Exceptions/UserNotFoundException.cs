namespace Application.User.Exceptions;

internal sealed class UserNotFoundException(string value) : CustomException($"No user with the provided value '{value}' was found in the system");