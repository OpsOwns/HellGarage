namespace Application.Abstractions.Security;

public interface IIdentity
{
    void Set(JwtDto jwt);
    JwtDto Get();
}