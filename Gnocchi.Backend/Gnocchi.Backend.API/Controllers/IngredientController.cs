using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Gnocchi.Backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientService _ingredientService;
    public IngredientsController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<IngredientDTO>>> Get()
    {
        var ingredientDTOs = await _ingredientService.GetAllIngredientsAsync();
        if (!ingredientDTOs.Any())
        {
            return NotFound();
        }

        return Ok(ingredientDTOs);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<ActionResult<IngredientDTO>> GetById([FromRoute]Guid id)
    {
        var ingredientDTO = await _ingredientService.GetIngredientByIdAsync(id.ToString());

        if(ingredientDTO is null)
        {
            return NotFound();
        }
        
        return Ok(ingredientDTO);
    }

    [HttpPost]
    public async Task<ActionResult<IngredientDTO>> Post([FromBody]CreateIngredientDTO DTO)
    {
        var result = await _ingredientService.AddIngredientAsync(DTO);

        return Created(result.IngredientId, result);
    }

    [HttpPatch]
    public async Task<ActionResult<IngredientDTO>> Patch([FromBody]UpdateIngredientDTO DTO)
    {
        var result = await _ingredientService.UpdateIngredientAsync(DTO);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]DeleteIngredientDTO DTO)
    {
        await _ingredientService.DeleteIngredientAsync(DTO);

        return NoContent();
    }
}