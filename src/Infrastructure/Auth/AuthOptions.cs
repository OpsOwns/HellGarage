namespace Infrastructure.Auth;

public class AuthOptions
{
    private const string OptionsSectionName = "Auth";
    public string Issuer { get; }
    public string Audience { get; }
    public string SigningKey { get; }
    public TimeSpan Expiry { get; }

    public AuthOptions(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        var section = configuration.GetSection(OptionsSectionName) ?? throw new ArgumentException($"{nameof(OptionsSectionName)} can't be null or empty");
        Issuer = section.GetValue<string>(nameof(Issuer)) ?? throw new ArgumentException($"{nameof(Issuer)} can't be null or empty");
        Audience = section.GetValue<string>(nameof(Audience)) ?? throw new ArgumentException($"{nameof(Audience)} can't be null or empty");
        SigningKey = section.GetValue<string>(nameof(SigningKey)) ?? throw new ArgumentException($"{nameof(SigningKey)} can't be null or empty");
        Expiry = section.GetValue<TimeSpan?>(nameof(Expiry)) ?? TimeSpan.FromHours(1);
    }
}