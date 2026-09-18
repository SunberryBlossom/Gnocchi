using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gnocchi.Backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RecipeStepController : ControllerBase
{
    private readonly IRecipeStepService _recipeStepService;

    public RecipeStepController(IRecipeStepService recipeStepService)
    {
        _recipeStepService = recipeStepService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<RecipeStepDTO>>> Get()
    {
        var steps = await _recipeStepService.GetAllRecipeStepsAsync();
        return Ok(steps);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeStepDTO>> GetById(string id)
    {
        var step = await _recipeStepService.GetRecipeStepByIdAsync(id);
        if (step is null) return NotFound();
        return Ok(step);
    }

  [HttpPost]
public async Task<ActionResult<RecipeStepDTO>> Post([FromBody] CreateRecipeStepDTO dto)
{
    var createdStep = await _recipeStepService.AddRecipeStepAsync(dto);
    return Ok(createdStep);
}

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteRecipeStepDTO dto)
    {
        await _recipeStepService.DeleteRecipeStepAsync(dto);
        return NoContent();
    }
}