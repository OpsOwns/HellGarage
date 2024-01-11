namespace Infrastructure.Database.Repositories;

public class UserRepository(HellDbContext hellDbContext) : IUserRepository
{
    private readonly DbSet<User> _users = hellDbContext.Users;

    public async Task CreateUserAsync(User user, CancellationToken cancellationToken = default) => await _users.AddAsync(user, cancellationToken);
}