namespace Application.User.RenewToken;

public record RenewTokenCommand(string AccessToken, string RefreshToken) : ICommand;