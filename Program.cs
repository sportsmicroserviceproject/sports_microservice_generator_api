using SportsGeneratorApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<IMatchGenerator, MatchGeneratorService>();

var app = builder.Build();

// Health check endpoint
app.MapGet("/health", () => "Healthy");

// Get all teams
app.MapGet("/teams", async (IMatchGenerator generator) =>
{
    var teams = await generator.GetTeamsAsync();
    return Results.Ok(teams);
});

// Generate a new match
app.MapPost("/generate-match", async (IMatchGenerator generator) =>
{
    var match = await generator.GenerateMatchAsync();
    return Results.Ok(match);
});

// Get specific match
app.MapGet("/matches/{id:int}", async (int id, IMatchGenerator generator) =>
{
    try
    {
        var match = await generator.GetMatchAsync(id);
        return Results.Ok(match);
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"Match {id} not found");
    }
});

app.Run();