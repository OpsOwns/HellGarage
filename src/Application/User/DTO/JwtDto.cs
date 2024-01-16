namespace Application.User.DTO;

public record JwtDto(string AccessToken, string RefreshToken);

public record JwtDtoEmpty() : JwtDto(string.Empty, string.Empty);