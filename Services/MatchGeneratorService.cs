using SportsGeneratorApi.Models;

namespace SportsGeneratorApi.Services;

public class MatchGeneratorService : IMatchGenerator
{
    private static readonly List<Team> _teams = new()
    {
        new Team { Id = 1, Name = "Manchester United", League = "Premier League" },
        new Team { Id = 2, Name = "Chelsea", League = "Premier League" },
        new Team { Id = 3, Name = "Liverpool", League = "Premier League" },
        new Team { Id = 4, Name = "Manchester City", League = "Premier League" },
        new Team { Id = 5, Name = "Arsenal", League = "Premier League" },
        new Team { Id = 6, Name = "Barcelona", League = "La Liga" },
        new Team { Id = 7, Name = "Real Madrid", League = "La Liga" }
    };

    private static readonly List<Match> _matches = new();
    private static int _nextMatchId = 1;
    private readonly Random _random = new();

    public Task<List<Team>> GetTeamsAsync()
    {
        return Task.FromResult(_teams);
    }

    public Task<Match> GetMatchAsync(int matchId)
    {
        var match = _matches.FirstOrDefault(m => m.Id == matchId);
        return Task.FromResult(match ?? throw new KeyNotFoundException($"Match {matchId} not found"));
    }

    public Task<Match> GenerateMatchAsync()
    {
        // Pick two random teams from same league
        var leagues = _teams.GroupBy(t => t.League).ToList();
        var selectedLeague = leagues[_random.Next(leagues.Count)];
        var leagueTeams = selectedLeague.ToList();

        if (leagueTeams.Count < 2)
        {
            throw new InvalidOperationException("Not enough teams in league");
        }

        var homeTeam = leagueTeams[_random.Next(leagueTeams.Count)];
        Team awayTeam;

        // Ensure different teams
        do
        {
            awayTeam = leagueTeams[_random.Next(leagueTeams.Count)];
        } while (awayTeam.Id == homeTeam.Id);

        var match = new Match
        {
            Id = _nextMatchId++,
            HomeTeamId = homeTeam.Id,
            AwayTeamId = awayTeam.Id,
            HomeScore = _random.Next(0, 5),
            AwayScore = _random.Next(0, 5),
            MatchDate = DateTime.UtcNow.AddDays(_random.Next(-7, 7)), // Random date within a week
            League = homeTeam.League,
            IsCompleted = true,
            HomeTeam = homeTeam,
            AwayTeam = awayTeam
        };

        _matches.Add(match);
        return Task.FromResult(match);
    }
}