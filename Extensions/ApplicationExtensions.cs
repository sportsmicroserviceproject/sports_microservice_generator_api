namespace SportsGeneratorApi.Extensions;

public static class ApplicationExtensions
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.UseCors("AllowFrontend");

        app.MapControllers();

        return app;
    }
}