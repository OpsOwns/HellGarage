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


await app.RunAsync();