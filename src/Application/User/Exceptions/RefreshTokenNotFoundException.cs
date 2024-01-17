namespace Application.User.Exceptions;

internal sealed class RefreshTokenNotFoundException(Guid userId) : CustomException($"No refresh token found for the User with ID '{userId}'.");