namespace Infrastructure.Database;

internal class HellGarageUnitOfWork(HellDbContext dbContext) : IUnitOfWork
{
    public async Task ExecuteAsync(Func<ValueTask> action, CancellationToken cancellationToken = default)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await action();
            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}