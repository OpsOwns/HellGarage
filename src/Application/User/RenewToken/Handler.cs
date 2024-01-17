namespace Application.User.RenewToken;

internal sealed class Handler(IAuthenticator authenticator, IUserRepository userRepository, TimeProvider timeProvider, IIdentity identity)
    : ICommandHandler<RenewTokenCommand>
{
    public async ValueTask HandleAsync(RenewTokenCommand command, CancellationToken cancellationToken = default)
    {
        authenticator.ValidatePrincipalFromExpiredToken(command.AccessToken);

        var userId = authenticator.GetUserIdFromJwtToken();

        var user = await userRepository.GetUserByIdAsync(userId, cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(userId.ToString());
        }

        if (user.RefreshToken is null)
        {
            throw new RefreshTokenNotFoundException(user.Id);
        }

        if (!user.RefreshToken.IsMatch(command.RefreshToken))
        {
            throw new RefreshTokenNotMatchException(command.RefreshToken);
        }

        if (user.RefreshToken.Revoked)
        {
            throw new RefreshTokenAlreadyRevoked(command.RefreshToken);
        }

        if (user.RefreshToken.IsExpired())
        {
            throw new RefreshTokenExpiredException(command.RefreshToken);
        }

        var token = authenticator.CreateAccessToken(user.Id, user.Email, user.Role);
        var refreshToken = RefreshToken.Generate();

        user.AssignRefreshToken(refreshToken);

        identity.Set(new JwtDto(token, refreshToken.Value));
    }
}