namespace Domain.User.Exceptions;

internal class InvalidPhoneException(string phone, string reason) : Exception($"Invalid phone '{phone}'. {reason}")
{
    public string Phone { get; } = phone;
    public string Reason { get; } = reason;
}