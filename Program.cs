using SportsGeneratorApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC controllers
builder.Services.AddControllers();

// Register application services
builder.Services.AddScoped<IMatchGenerator, MatchGeneratorService>();

var app = builder.Build();

// Map controller endpoints
app.MapControllers();

app.Run();