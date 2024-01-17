namespace Application.User.SignIn;

internal sealed class Handler(IUserRepository userRepository, IAuthenticator authenticator, IIdentity identity) : ICommandHandler<SignInCommand>
{
    public async ValueTask HandleAsync(SignInCommand command, CancellationToken cancellationToken = default)
    {
        var email = Email.Create(command.Email);
        var password = Password.Create(command.Password);

        var user = await userRepository.GetUserAsync(email, cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(email.Value);
        }

        if (!password.IsMatch(user.HashedPassword))
        {
            throw new InvalidPasswordException(password);
        }

        var token = authenticator.CreateAccessToken(user.Id, user.Email, user.Role);
        var refreshToken = RefreshToken.Generate();

        user.AssignRefreshToken(refreshToken);

        identity.Set(new JwtDto(token, refreshToken.Value));
    }
}