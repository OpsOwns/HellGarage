namespace API.EndPoints.User.Requests;

public record RefreshTokenRequest(string AccessToken, string RefreshToken);