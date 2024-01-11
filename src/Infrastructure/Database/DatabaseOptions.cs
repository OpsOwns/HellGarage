namespace Infrastructure.Database;

internal sealed class DatabaseOptions
{
    public string ConnectionString { get; }

    public DatabaseOptions(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        var connectionString = configuration.GetValue<string>(nameof(ConnectionString));

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException($"{nameof(ConnectionString)} can't be null or empty");
        }

        ConnectionString = connectionString;
    }
}