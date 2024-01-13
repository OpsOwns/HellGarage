var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddInfrastructure();
builder.Logging.AddConsole();

var app = builder.Build();

app.UseExceptionHandler(_ => { });

if (app.Environment.IsDevelopment())
{
    builder.Configuration
        .AddUserSecrets<Program>()
        .AddEnvironmentVariables();
}

app.UseHttpsRedirection();
app.MapUserEndpoints();

app.MapGet("/", context => context.Response.WriteAsync("HellGarage API Backend :)"));

await app.RunAsync();