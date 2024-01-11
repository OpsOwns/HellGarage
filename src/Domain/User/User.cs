namespace Domain.User;

public sealed class User : Entity
{
    public Email Email { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public HashedPassword HashedPassword { get; private set; }
    public Profession Profession { get; private set; }
    public Phone Phone { get; private set; }
    private User(){}
    private User(FirstName firstName,
        LastName lastName,
        HashedPassword hashedPassword,
        Email email,
        Profession profession,
        Phone phone,
        Guid id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        HashedPassword = hashedPassword;
        Profession = profession;
        Phone = phone;
        Id = id;
    }

    public static User Create(FirstName firstName, LastName lastName, Password password, Email email, Profession profession, Phone phone) =>
        new(firstName, lastName, password.Hash(), email, profession, phone, Guid.NewGuid());
}