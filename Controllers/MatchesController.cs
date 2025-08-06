using Microsoft.AspNetCore.Mvc;
using SportsGeneratorApi.Services;

namespace SportsGeneratorApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchesController : ControllerBase
{
    private readonly IMatchGenerator _matchGenerator;

    public MatchesController(IMatchGenerator matchGenerator)
    {
        _matchGenerator = matchGenerator;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateMatch()
    {
        var match = await _matchGenerator.GenerateMatchAsync();
        return Ok(match);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMatch(int id)
    {
        try
        {
            var match = await _matchGenerator.GetMatchAsync(id);
            return Ok(match);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Match {id} not found");
        }
    }
}