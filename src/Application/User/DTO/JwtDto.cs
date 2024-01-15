namespace Application.User.DTO;

public record JwtDto(string AccessToken);

public record JwtDtoEmpty() : JwtDto(string.Empty);