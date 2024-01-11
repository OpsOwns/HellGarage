namespace Application.User.CreateUser;

public sealed record Command(string Email, string FirstName, string LastName, string Phone, string Password) : ICommand;