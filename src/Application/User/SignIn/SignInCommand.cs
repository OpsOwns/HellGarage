namespace Application.User.SignIn;

public record SignInCommand(string Email, string Password) : ICommand;