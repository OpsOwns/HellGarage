namespace Infrastructure.Database.Decorators;

internal sealed class UnitOfWorkCommandHandlerDecorator<TCommand>(ICommandHandler<TCommand> commandHandler, IUnitOfWork unitOfWork) : ICommandHandler<TCommand>
    where TCommand : class, ICommand
{
    public async ValueTask<Result> HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        return await unitOfWork.ExecuteAsync(() => commandHandler.HandleAsync(command, cancellationToken), cancellationToken);
    }
}