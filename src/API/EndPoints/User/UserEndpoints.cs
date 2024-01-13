namespace API.EndPoints.User;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/user");

        group.MapPost("", async (CreateUserRequest request, ICommandDispatcher commandDispatcher, CancellationToken cancellationToken) =>
        {
            var userCommand = new Command(request.Email, request.FirstName, request.LastName, request.Phone, request.Password);

            await commandDispatcher.CommandAsync(userCommand, cancellationToken);

            return Results.Ok();
        });
    }
}