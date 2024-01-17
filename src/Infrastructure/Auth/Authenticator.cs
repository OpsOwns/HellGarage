namespace Infrastructure.Auth;

internal sealed class Authenticator(AuthOptions options, TimeProvider timeProvider, TokenValidationParameters tokenValidationParameters) : IAuthenticator
{
    private readonly SigningCredentials _signingCredentials = new(new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(options.SigningKey)),
        SecurityAlgorithms.HmacSha256);

    private ClaimsPrincipal? _claimsPrincipal;

    private readonly JwtSecurityTokenHandler _jwtSecurityToken = new();

    public string CreateAccessToken(Guid userId, Email email, Role role)
    {
        var now = timeProvider.GetUtcNow();
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new(ClaimTypes.Email, email.Value),
            new(ClaimTypes.Role, role.ToString())
        };

        var expires = now.Add(options.Expiry);
        var jwt = new JwtSecurityToken(options.SigningKey, options.Audience, claims, now.DateTime, expires.DateTime, _signingCredentials);
        var token = _jwtSecurityToken.WriteToken(jwt);

        return token;
    }

    public void ValidatePrincipalFromExpiredToken(string accessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        _claimsPrincipal =
            tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");
    }

    public Guid GetUserIdFromJwtToken()
    {
        if (_claimsPrincipal is null)
            throw new InvalidOperationException();

        return Guid.Parse(_claimsPrincipal.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);
    }
}