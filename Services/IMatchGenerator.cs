using SportsGeneratorApi.Models;

namespace SportsGeneratorApi.Services;

public interface IMatchGenerator
{
    Task<Match> GenerateMatchAsync();
    Task<List<Team>> GetTeamsAsync();
    Task<Match> GetMatchAsync(int matchId);
}