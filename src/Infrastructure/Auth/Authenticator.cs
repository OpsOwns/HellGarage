namespace Infrastructure.Auth;

internal sealed class Authenticator(AuthOptions options, IClock clock) : IAuthenticator
{
    private readonly SigningCredentials _signingCredentials = new(new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(options.SigningKey)),
        SecurityAlgorithms.HmacSha256);

    private readonly JwtSecurityTokenHandler _jwtSecurityToken = new();

    public JwtDto CreateToken(Guid userId, Email email)
    {
        var now = clock.Current();
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new(ClaimTypes.Email, email.Value)
        };

        var expires = now.Add(options.Expiry);
        var jwt = new JwtSecurityToken(options.SigningKey, options.Audience, claims, now, expires, _signingCredentials);
        var token = _jwtSecurityToken.WriteToken(jwt);

        return new JwtDto(token);
    }
}