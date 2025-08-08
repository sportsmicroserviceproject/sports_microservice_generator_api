using SportsGeneratorApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure services, using /Extensions for startup configuration and /Services for business logic
builder.Services.AddApplicationServices();
builder.Services.AddCorsPolicy();

var app = builder.Build();

// Configure application
app.ConfigureApplication();

app.Run();