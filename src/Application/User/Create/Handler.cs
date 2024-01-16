namespace Application.User.Create;

using Domain.User;

internal sealed class Handler(IUserRepository userRepository) : ICommandHandler<CreateCommand>
{
    public async ValueTask HandleAsync(CreateCommand createCommand, CancellationToken cancellationToken = default)
    {
        var email = Email.Create(createCommand.Email);
        var firstName = FirstName.Create(createCommand.FirstName);
        var lastName = LastName.Create(createCommand.LastName);
        var phone = Phone.Create(createCommand.Phone);
        var password = Password.Create(createCommand.Password);

        if (await userRepository.IsEmailExists(email, cancellationToken))
        {
            throw new EmailAlreadyExistsException(email.Value);
        }

        var user = User.Create(firstName, lastName, password, email, Profession.Cleaner, phone);
        await userRepository.CreateUserAsync(user, cancellationToken);
    }
}