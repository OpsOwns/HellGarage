namespace Domain.User.Exceptions;

internal class InvalidLastNameException(string lastName, string reason) : Exception($"Invalid last name '{lastName}'. {reason}")
{
    public string LastName { get; } = lastName;
    public string Reason { get; } = reason;
}