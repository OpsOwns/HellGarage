namespace Domain.User.Abstractions;

public interface IUserRepository : IRepository
{
    Task CreateUserAsync(User user, CancellationToken cancellationToken = default);
    Task<bool> IsEmailExists(Email userEmail, CancellationToken cancellationToken = default);
    Task<User?> GetUserAsync(Email email, CancellationToken cancellationToken = default);
}