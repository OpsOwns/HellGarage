namespace Infrastructure.Auth;

public static class Installer
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddSingleton(x => new AuthOptions(x.GetRequiredService<IConfiguration>()));

        var options = services.BuildServiceProvider().GetRequiredService<AuthOptions>();

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = options.Issuer,
            ClockSkew = TimeSpan.Zero,
            RequireAudience = true,
            ValidateIssuer = false,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey)),
            ValidateLifetime = true,
            ValidateActor = false,
            ValidateTokenReplay = false,
            ValidateIssuerSigningKey = true
        };

        services.AddSingleton(tokenValidationParameters)
            .AddSingleton<IAuthenticator, Authenticator>()
            .AddSingleton<IIdentity, Identity>()
            .AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.Audience = options.Audience;
                o.IncludeErrorDetails = true;
                o.TokenValidationParameters = tokenValidationParameters;
            });

        services.AddAuthorizationBuilder()
            .AddPolicy("admin", policy => { policy.RequireRole("admin"); })
            .AddPolicy("user", policy => { policy.RequireRole("user"); });

        return services;
    }
}