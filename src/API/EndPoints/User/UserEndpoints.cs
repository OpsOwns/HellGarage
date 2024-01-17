namespace API.EndPoints.User;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/user");

        group.RequireAuthorization(EndPointsExtensions.Admin).MapPost("create", async (CreateRequest request, ICommandDispatcher commandDispatcher, CancellationToken cancellationToken) =>
        {
            var userCommand = new CreateCommand(request.Email, request.FirstName, request.LastName, request.Phone, request.Password);

            await commandDispatcher.CommandAsync(userCommand, cancellationToken);

            return Results.Ok();
        });

        group.AllowAnonymous().MapPost("sign-in", async (LoginRequest request, ICommandDispatcher commandDispatcher, CancellationToken cancellationToken) =>
        {
            var signInCommand = new SignInCommand(request.Email, request.Password);

            await commandDispatcher.CommandAsync(signInCommand, cancellationToken);

            return Results.Ok();
        });

        group.AllowAnonymous().MapPost("refresh-token", async (RefreshTokenRequest request,
            ICommandDispatcher commandDispatcher, CancellationToken cancellationToken) =>
        {
            var renewTokenCommand = new RenewTokenCommand(request.AccessToken, request.RefreshToken);

            await commandDispatcher.CommandAsync(renewTokenCommand, cancellationToken);

            return Results.Ok();
        });
    }
}