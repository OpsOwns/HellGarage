namespace Application.User.Exceptions;

internal sealed class RefreshTokenNotMatchException(string token) : CustomException($"The provided refresh token '{token}' does not match the user's token.");