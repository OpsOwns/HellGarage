namespace Domain.User.Exceptions;

internal class EmptyHashException() : CustomException("The hashed password cannot be empty or whitespace.");