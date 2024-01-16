namespace Domain.User;

public sealed class User : Entity
{
    public Email Email { get; private set; } = null!;
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public HashedPassword HashedPassword { get; private set; } = null!;
    public Profession Profession { get; private set; } = null!;
    public Phone Phone { get; private set; } = null!;
    public RefreshToken? RefreshToken { get; private set; }

    private User()
    {
    }

    private User(FirstName firstName,
        LastName lastName,
        HashedPassword hashedPassword,
        Email email,
        Profession profession,
        Phone phone,
        RefreshToken? refreshToken = null) : base(Guid.NewGuid())
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        HashedPassword = hashedPassword;
        Profession = profession;
        Phone = phone;
        RefreshToken = refreshToken;
    }

    public static User Create(FirstName firstName, LastName lastName, Password password, Email email, Profession profession, Phone phone) =>
        new(firstName, lastName, password.Hash(), email, profession, phone);


    public void AssignRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken = refreshToken;
    }
}