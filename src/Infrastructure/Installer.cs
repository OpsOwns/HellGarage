namespace Infrastructure;

public static class Installer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddSingleton<IClock, Clock>();
        services.AddCqrsDispatcher();
        services.AddDatabase();
        services.AddAuth();
        
        return services;
    }
}