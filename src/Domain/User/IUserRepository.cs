namespace Domain.User;

public interface IUserRepository : IRepository
{
    Task CreateUserAsync(User user, CancellationToken cancellationToken = default);
    Task<bool> IsEmailExists(Email userEmail, CancellationToken cancellationToken = default);
}