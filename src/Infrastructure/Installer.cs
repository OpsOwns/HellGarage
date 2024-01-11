namespace Infrastructure;

public static class Installer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddCqrsDispatcher();
        services.AddDatabase();
        return services;
    }
}