using Microsoft.AspNetCore.Mvc;
using SportsGeneratorApi.Services;

namespace SportsGeneratorApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private readonly IMatchGenerator _matchGenerator;

    public TeamsController(IMatchGenerator matchGenerator)
    {
        _matchGenerator = matchGenerator;
    }

    [HttpGet]
    public async Task<IActionResult> GetTeams()
    {
        var teams = await _matchGenerator.GetTeamsAsync();
        return Ok(teams);
    }
}