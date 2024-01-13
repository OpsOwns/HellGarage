namespace Infrastructure.Database.Abstractions;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<ValueTask> action, CancellationToken cancellationToken = default);
}