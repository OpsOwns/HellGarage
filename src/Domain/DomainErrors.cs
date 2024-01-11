using Domain.User;

namespace Domain;

public static class DomainErrors
{
    public static class General
    {
        public static Error ValueTooShort(int value) => new("General.ValueTooShort", $"The provided value {value} is too short. Please enter a larger value.");
        public static Error ValueTooLong(int value) => new("General.ValueTooLong", $"The provided value {value} is too long. Please enter a smaller value.");
        public static Error ValueIsRequired() => new("General.ValueIsRequired", "The provided value is missing. Please ensure to enter a valid value.");
    }

    public static class User
    {
        public static Error NotFound => new("User.NotFound", "The user with the specified identifier was not found.");

        public static Error PasswordBreakComplexityRules() => new("User.PasswordComplexity", "The provided password doesn't meet the complexity requirements." +
                                                                                             " It must contain at least one uppercase letter, " +
                                                                                             "one lowercase letter, a number, and a special character.");

        public static Error InvalidEmail(string email) => new("User.InvalidEmail", $"The provided email `{email}` is invalid.");
        public static Error InvalidCharacters(string name) => new("User.InvalidCharacters", $"{name} should only contain letters.");
        public static Error OutOfRangeCharacter(string name) => new("User.RangeCharacter", $"{name} must be between 2 and 50 characters.");
        public static Error InvalidPhoneNumber(string number) => new("User.InvalidPhoneNumber", $"Provided number '{number}' is invalid.");
    }
}