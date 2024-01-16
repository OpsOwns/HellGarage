namespace API.EndPoints.User;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/user");

        group.MapPost("create", async (CreateRequest request, ICommandDispatcher commandDispatcher, CancellationToken cancellationToken) =>
        {
            var userCommand = new CreateCommand(request.Email, request.FirstName, request.LastName, request.Phone, request.Password);

            await commandDispatcher.CommandAsync(userCommand, cancellationToken);

            return Results.Ok();
        });
        group.MapPost("sign-in", async (LoginRequest request, ICommandDispatcher commandDispatcher, CancellationToken cancellationToken) =>
        {
            var signInCommand = new SignInCommand(request.Email, request.Password);

            await commandDispatcher.CommandAsync(signInCommand, cancellationToken);

            return Results.Ok();
        });
    }
}