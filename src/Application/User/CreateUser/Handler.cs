namespace Application.User.CreateUser;

internal sealed class Handler(IUserRepository userRepository) : ICommandHandler<Command>
{
    public async ValueTask HandleAsync(Command command, CancellationToken cancellationToken = default)
    {
        var email = Email.Create(command.Email);
        var firstName = FirstName.Create(command.FirstName);
        var lastName = LastName.Create(command.LastName);
        var phone = Phone.Create(command.Phone);
        var password = Password.Create(command.Password);

        if (await userRepository.IsEmailExists(email, cancellationToken))
        {
            throw new EmailAlreadyExistsException(email.Value);
        }

        var user = Domain.User.User.Create(firstName, lastName, password, email, Profession.Cleaner, phone);
        await userRepository.CreateUserAsync(user, cancellationToken);
    }
}