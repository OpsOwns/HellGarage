namespace Application.Abstractions.Commands;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    ValueTask HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}