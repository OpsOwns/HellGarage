namespace Domain.User.Exceptions;

public class EmailAlreadyExistsException(string email) : CustomException($"The '{email}' email already exists in the system.");