namespace API.EndPoints.User.Requests;

public record CreateRequest(string FirstName, string LastName, string Email, string Password, string Phone);