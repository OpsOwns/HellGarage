namespace Infrastructure.Cqrs.Abstractions;

public interface IQueryDispatcher
{
    ValueTask<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}