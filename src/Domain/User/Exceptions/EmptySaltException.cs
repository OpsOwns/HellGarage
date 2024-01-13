namespace Domain.User.Exceptions;

internal class EmptySaltException() : CustomException("The salt cannot be empty or whitespace.");