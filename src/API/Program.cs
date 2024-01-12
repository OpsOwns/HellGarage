using API.EndPoints.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure();

var app = builder.Build();

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