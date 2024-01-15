namespace Application.Abstractions.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, Email email);
}