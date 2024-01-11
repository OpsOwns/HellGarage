namespace Infrastructure.Database;

public static class Installer
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddRepositories();
        services.AddHostedService<DatabaseInitializer>();
        services.AddScoped<IUnitOfWork, HellGarageUnitOfWork>();
        services.AddSingleton(x => new DatabaseOptions(x.GetRequiredService<IConfiguration>()));
        services.AddDbContext<HellDbContext>((provider, options) =>
        {
            var databaseOptions = provider.GetRequiredService<DatabaseOptions>();
            options.UseSqlServer(databaseOptions.ConnectionString);
        });
        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        return services;
    }
}