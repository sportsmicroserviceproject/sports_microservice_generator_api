namespace SportsGeneratorApi.Models;

public class Match
{
    public int Id { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public DateTime MatchDate { get; set; }
    public string League { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    
    // Navigation properties (for future use with EF Core)
    public Team? HomeTeam { get; set; }
    public Team? AwayTeam { get; set; }
}