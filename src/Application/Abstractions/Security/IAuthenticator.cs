namespace Application.Abstractions.Security;

public interface IAuthenticator
{
    string CreateAccessToken(Guid userId, Email email);
}