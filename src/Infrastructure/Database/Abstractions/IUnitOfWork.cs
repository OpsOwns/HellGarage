namespace Infrastructure.Database.Abstractions;

public interface IUnitOfWork
{
    Task<Result> ExecuteAsync(Func<ValueTask<Result>> action, CancellationToken cancellationToken = default);
}