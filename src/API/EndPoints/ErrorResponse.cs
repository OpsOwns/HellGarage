namespace API.EndPoints;

public record ErrorResponse
{
    public IEnumerable<Error> Errors { get; }

    public ErrorResponse(params Error[] errors)
    {
        Errors = errors ?? throw new ArgumentNullException(nameof(errors));
    }
}