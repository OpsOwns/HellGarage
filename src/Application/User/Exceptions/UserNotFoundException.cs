namespace Application.User.Exceptions;

internal sealed class UserNotFoundException(Email email) : CustomException($"No user with the email '{email.Value}' was found in the system");