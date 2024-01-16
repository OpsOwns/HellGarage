namespace Infrastructure.Auth;

internal sealed class Authenticator(AuthOptions options, TimeProvider timeProvider) : IAuthenticator
{
    private readonly SigningCredentials _signingCredentials = new(new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(options.SigningKey)),
        SecurityAlgorithms.HmacSha256);

    private readonly JwtSecurityTokenHandler _jwtSecurityToken = new();

    public string CreateAccessToken(Guid userId, Email email)
    {
        var now = timeProvider.GetUtcNow();
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new(ClaimTypes.Email, email.Value)
        };

        var expires = now.Add(options.Expiry);
        var jwt = new JwtSecurityToken(options.SigningKey, options.Audience, claims, now.DateTime, expires.DateTime, _signingCredentials);
        var token = _jwtSecurityToken.WriteToken(jwt);

        return token;
    }
}