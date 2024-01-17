namespace Application.User.Exceptions;

internal sealed class RefreshTokenAlreadyRevoked(string token) : CustomException($"The provided token '{token}' has already been revoked.");