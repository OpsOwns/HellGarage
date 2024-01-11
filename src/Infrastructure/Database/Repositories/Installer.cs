namespace Infrastructure.Database.Repositories;

public static class Installer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(c => c.AssignableTo(typeof(IRepository)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}