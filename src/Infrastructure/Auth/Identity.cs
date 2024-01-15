namespace Infrastructure.Auth;

internal sealed class Identity(IHttpContextAccessor httpContextAccessor) : IIdentity
{
    private const string TokenKey = "jwt";

    public void Set(JwtDto jwt) => httpContextAccessor.HttpContext?.Items.TryAdd(TokenKey, jwt);

    public JwtDto Get()
    {
        if (httpContextAccessor.HttpContext is null)
        {
            return new JwtDtoEmpty();
        }

        if (!httpContextAccessor.HttpContext.Items.TryGetValue(TokenKey, out var jwt))
            return new JwtDtoEmpty();
        
        if (jwt is JwtDto dto)
        {
            return dto;
        }

        return new JwtDtoEmpty();
    }
}