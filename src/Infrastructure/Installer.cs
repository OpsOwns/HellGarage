namespace Infrastructure;

public static class Installer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddSingleton(TimeProvider.System);
        services.AddCqrsDispatcher();
        services.AddDatabase();
        services.AddAuth();

        return services;
    }
}