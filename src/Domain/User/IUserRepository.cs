namespace Domain.User;

public interface IUserRepository : IRepository
{
    Task CreateUserAsync(User user, CancellationToken cancellationToken = default);
}