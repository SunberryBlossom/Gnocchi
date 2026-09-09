using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gnocchi.Backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScoresController : ControllerBase
{
private readonly IScoreService _scoreService;
    public ScoresController(IScoreService scoreService)
    {
        _scoreService = scoreService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ScoreDTO>>> Get()
    {
        var scoreDTOs = await _scoreService.GetAllScoresAsync();
        if (!scoreDTOs.Any())
        {
            return NotFound();
        }

        return Ok(scoreDTOs);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<ActionResult<ScoreDTO>> GetById([FromRoute]Guid id)
    {
        var scoreDTO = await _scoreService.GetScoreByIdAsync(id.ToString());

        if(scoreDTO is null)
        {
            return NotFound();
        }
        
        return Ok(scoreDTO);
    }

    [HttpPost]
    public async Task<ActionResult<ScoreDTO>> Post([FromBody]CreateScoreDTO DTO)
    {
        var score = await _scoreService.AddScoreAsync(DTO);

        return Created(score.ScoreId, score);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]DeleteScoreDTO DTO)
    {
        await _scoreService.DeleteScoreAsync(DTO);

        return NoContent();
    }
}