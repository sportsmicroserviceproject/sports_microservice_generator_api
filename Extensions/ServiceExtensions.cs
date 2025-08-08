using SportsGeneratorApi.Services;

namespace SportsGeneratorApi.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Add MVC controllers, we use this pattern to keep Program.cs clean
        services.AddControllers();

        // Register business services
        services.AddScoped<IMatchGenerator, MatchGeneratorService>();

        return services;
    }

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("https://mymh.dev", "http://mymh.dev")
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        return services;
    }
}