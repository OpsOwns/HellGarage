namespace Infrastructure.Database;

public class DatabaseInitializer(IServiceProvider serviceProvider, ILogger<DatabaseInitializer> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<HellDbContext>();

        try
        {
            await context.Database
                .EnsureCreatedAsync(cancellationToken);

            logger.LogInformation("Initialize database success");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Initialize database failed");
            throw;
        }
    }
}