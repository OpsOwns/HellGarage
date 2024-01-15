namespace Infrastructure.Auth;

public static class Installer
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddSingleton(x => new AuthOptions(x.GetRequiredService<IConfiguration>()));

        var options = services.BuildServiceProvider().GetRequiredService<AuthOptions>();

        services
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
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = options.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey))
                };
            });

        services.AddAuthorizationBuilder()
            .AddPolicy("is-admin", policy =>
            {
                policy.RequireRole("admin");
            });

        return services;
    }
}