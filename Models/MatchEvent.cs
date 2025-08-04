namespace SportsGeneratorApi.Models;

public class MatchEvent
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public string EventType { get; set; } = string.Empty; // "Goal", "Card", "Substitution"
    public int TeamId { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public int MinuteOfMatch { get; set; }
    public string Description { get; set; } = string.Empty;
    
    // Navigation properties
    public Match? Match { get; set; }
    public Team? Team { get; set; }
}