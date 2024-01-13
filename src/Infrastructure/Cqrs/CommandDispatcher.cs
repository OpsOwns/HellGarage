namespace Infrastructure.Cqrs;

public sealed class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public async ValueTask CommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand
    {
        using var scope = serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.HandleAsync(command, cancellationToken).ConfigureAwait(false);
    }
}