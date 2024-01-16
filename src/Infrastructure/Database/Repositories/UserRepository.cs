﻿namespace Infrastructure.Database.Repositories;

public class UserRepository(HellDbContext hellDbContext) : IUserRepository
{
    private readonly DbSet<User> _users = hellDbContext.Users;

    public async Task CreateUserAsync(User user, CancellationToken cancellationToken = default) => await _users.AddAsync(user, cancellationToken);

    public async Task<bool> IsEmailExists(Email userEmail, CancellationToken cancellationToken = default) =>
        await _users.AnyAsync(x => x.Email == userEmail, cancellationToken);

    public async Task<User?> GetUserAsync(Email email, CancellationToken cancellationToken = default) =>
        await _users.SingleOrDefaultAsync(x => x.Email == email, cancellationToken);
}