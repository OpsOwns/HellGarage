namespace Application.User.Create;

public sealed record CreateCommand(string Email, string FirstName, string LastName, string Phone, string Password) : ICommand;