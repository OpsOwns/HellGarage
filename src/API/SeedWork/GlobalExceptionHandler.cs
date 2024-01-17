namespace API.SeedWork;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);

        var (statusCode, error) = exception switch
        {
            CustomException => (StatusCodes.Status400BadRequest,
                new Error(exception.GetType().Name.Underscore().Replace("_exception", string.Empty), exception.Message)),
            SecurityTokenValidationException => (StatusCodes.Status400BadRequest,
                new Error(exception.GetType().Name.Underscore().Replace("_exception", string.Empty), exception.Message)),
            _ => (StatusCodes.Status500InternalServerError, new Error("error", "There was an error."))
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(error, cancellationToken: cancellationToken);

        return true;
    }
}