namespace SportsGeneratorApi.Configuration;

public class DatabaseOptions
{
    public const string SectionName = "Database";
    
    public string ConnectionString { get; set; } = string.Empty;
    public bool EnableDetailedLogging { get; set; } = false;
    public int CommandTimeout { get; set; } = 30;
}