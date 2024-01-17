namespace Application.User.Exceptions;

internal sealed class RefreshTokenExpiredException(string token) :  CustomException($"The provided token '{token}' has already been expired.");