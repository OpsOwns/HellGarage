namespace Domain.Tests;

public class UserTests
{
    [Fact]
    public void CreateUserSuccess()
    {
        var firstName = FirstName.Create("John").Value;
        var lastName = LastName.Create("Don").Value;
        var email = Email.Create("GiveMeSomeTests@gmail.com").Value;
        var phone = Phone.Create("123456789").Value;
        var password = Password.Create("Test123$").Value;
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
        
        email.IsSuccess.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("InvalidEmail")]
    [InlineData("")]
    [InlineData("gainAnGmail.com")]
    public void CreateEmailWithWrongStructureIsInvalid(string value)
    {
        var email = Email.Create(value);

        email.IsFailure.Should().BeTrue();
        email.IsSuccess.Should().BeFalse();
    }
    
    [Theory]
    [InlineData("John")]
    [InlineData("Alice")]
    public void CreateFirstNameWithValueSuccess(string value)
    {
        var firstName = FirstName.Create(value);

        firstName.IsSuccess.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void CreateFirstNameWithValueInvalid(string value)
    {
        var firstName = FirstName.Create(value);

        firstName.IsFailure.Should().BeTrue();
        firstName.IsSuccess.Should().BeFalse();
    }
    
    [Theory]
    [InlineData("123456789")]
    [InlineData("987654321")]
    public void CreatePhoneWithValueSuccess(string value)
    {
        var phone = Phone.Create(value);

        phone.IsSuccess.Should().BeTrue();
    }

    [Theory]
    [InlineData("12356643")]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("InvalidPhone")]
    public void CreatePhoneWithValueInvalid(string value)
    {
        var phone = Phone.Create(value);

        phone.IsFailure.Should().BeTrue();
        phone.IsSuccess.Should().BeFalse();
    }

    [Theory]
    [InlineData("ValidPassword123$")]
    [InlineData("AnotherTest@123")]
    public void CreatePasswordWithValueSuccess(string value)
    {
        var password = Password.Create(value);

        password.IsSuccess.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("InvalidPass")]
    public void CreatePasswordWithValueInvalid(string value)
    {
        var password = Password.Create(value);

        password.IsFailure.Should().BeTrue();
        password.IsSuccess.Should().BeFalse();
    }
}