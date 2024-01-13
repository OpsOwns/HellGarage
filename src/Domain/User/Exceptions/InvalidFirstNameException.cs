namespace Domain.User.Exceptions;

internal class InvalidFirstNameException(string firstName, string reason) : Exception($"Invalid first name '{firstName}'. {reason}")
{
    public string FirstName { get; } = firstName;
    public string Reason { get; } = reason;
}