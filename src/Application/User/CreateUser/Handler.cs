namespace Application.User.CreateUser;

internal sealed class Handler(IUserRepository userRepository) : ICommandHandler<Command>
{
    public async ValueTask<Result> HandleAsync(Command command, CancellationToken cancellationToken = default)
    {
        var email = Email.Create(command.Email);
        var firstName = FirstName.Create(command.FirstName);
        var lastName = LastName.Create(command.LastName);
        var phone = Phone.Create(command.Phone);
        var password = Password.Create(command.Password);

        var errorResult = Result.Combine(email, firstName, lastName, password, phone);

        if (errorResult.IsFailure)
        {
            return errorResult;
        }

        var user = Domain.User.User.Create(firstName.Value, lastName.Value, password.Value, email.Value, Profession.Cleaner, phone.Value);
        await userRepository.CreateUserAsync(user, cancellationToken);

        return Result.Success();
    }
}