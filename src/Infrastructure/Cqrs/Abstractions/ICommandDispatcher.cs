namespace Infrastructure.Cqrs.Abstractions;

public interface ICommandDispatcher
{
    ValueTask<Result> CommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;
}