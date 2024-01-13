namespace Application.User.Exceptions;

internal class EmailAlreadyExistsException(string email) : CustomException($"The '{email}' email already exists in the system.");