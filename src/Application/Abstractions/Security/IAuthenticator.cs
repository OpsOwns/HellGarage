namespace Application.Abstractions.Security;

public interface IAuthenticator
{
    string CreateAccessToken(Guid userId, Email email, Role role);
    void ValidatePrincipalFromExpiredToken(string accessToken);
    Guid GetUserIdFromJwtToken();
}