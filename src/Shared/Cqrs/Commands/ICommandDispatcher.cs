namespace Shared.Cqrs.Commands;

public interface ICommandDispatcher
{
    ValueTask CommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;
}