namespace Domain.Tests;

public class UserTests
{
    [Fact]
    public void CreateUserSuccess()
    {
        var firstName = FirstName.Create("John");
        var lastName = LastName.Create("Don");
        var email = Email.Create("GiveMeSomeTests@gmail.com");
        var phone = Phone.Create("123456789");
        var password = Password.Create("Test123$");
        var profession = Profession.Mechanic;

        var user = User.User.Create(firstName, lastName, password, email, profession, phone);


        user.Should().NotBeNull();
        user.Id.Should().NotBeEmpty();
    }

    [Theory]
    [InlineData("GiveMeMyMoney@gmail.com")]
    [InlineData("test@yahoo.com")]
    public void CreateEmailWithCorrectStructureSuccess(string value)
    {
        var email = Email.Create(value);

        email.Should().NotBeNull();
        email.Value.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData("InvalidEmail")]
    [InlineData("")]
    [InlineData("gainAnGmail.com")]
    public void CreateEmailWithWrongStructureIsInvalid(string value)
    {
        Action action = () => Email.Create(value);

        action.Should().Throw<InvalidEmailException>();
    }

    [Theory]
    [InlineData("John")]
    [InlineData("Alice")]
    public void CreateFirstNameWithValueSuccess(string value)
    {
        var firstName = FirstName.Create(value);

        firstName.Should().NotBeNull();
        firstName.Value.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void CreateFirstNameWithValueInvalid(string value)
    {
        Action action = () => FirstName.Create(value);

        action.Should().Throw<InvalidFirstNameException>();
    }

    [Theory]
    [InlineData("123456789")]
    [InlineData("987654321")]
    public void CreatePhoneWithValueSuccess(string value)
    {
        var phone = Phone.Create(value);

        phone.Should().NotBeNull();
        phone.Value.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData("12356643")]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("InvalidPhone")]
    public void CreatePhoneWithValueInvalid(string value)
    {
        Action action = () => Phone.Create(value);

        action.Should().Throw<InvalidPhoneException>();
    }

    [Theory]
    [InlineData("ValidPassword123$")]
    [InlineData("AnotherTest@123")]
    public void CreatePasswordWithValueSuccess(string value)
    {
        var password = Password.Create(value);

        password.Should().NotBeNull();
        password.Value.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("InvalidPass")]
    public void CreatePasswordWithValueInvalid(string value)
    {
        Action action = () => Password.Create(value);

        action.Should().Throw<InvalidPasswordException>();
    }
}