namespace Infrastructure.Auth;

internal sealed class Identity(IHttpContextAccessor httpContextAccessor, TimeProvider timeProvider) : IIdentity
{
    private const string TokenKey = "jwt";

    public void Set(JwtDto jwt)
    {
        if (httpContextAccessor.HttpContext is null)
        {
            return;
        }

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = timeProvider.GetUtcNow().AddDays(7)
        };

        httpContextAccessor.HttpContext.Response.Cookies.Append("jwtAccessToken", jwt.AccessToken, cookieOptions);
        httpContextAccessor.HttpContext.Response.Cookies.Append("jwtRefreshToken", jwt.RefreshToken, cookieOptions);
        httpContextAccessor.HttpContext.Items.Add(TokenKey, jwt);
    }

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