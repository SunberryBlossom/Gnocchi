using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Gnocchi.Backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CookingMethodsController : ControllerBase
{
    private readonly ICookingMethodService _cookingMethodService;
    public CookingMethodsController(ICookingMethodService cookingMethodService)
    {
        _cookingMethodService = cookingMethodService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CookingMethodDTO>>> Get()
    {
        var cookingMethodDTOs = await _cookingMethodService.GetAllCookingMethodsAsync();
        if (!cookingMethodDTOs.Any())
        {
            return NotFound();
        }

        return Ok(cookingMethodDTOs);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<ActionResult<CookingMethodDTO>> GetById([FromRoute]Guid id)
    {
        var CookingMethodDTO = await _cookingMethodService.GetCookingMethodByIdAsync(id.ToString());

        if(CookingMethodDTO is null)
        {
            return NotFound();
        }
        
        return Ok(CookingMethodDTO);
    }

    [HttpPost]
    public async Task<ActionResult<CookingMethodDTO>> Post([FromBody]CreateCookingMethodDTO DTO)
    {
        var result = await _cookingMethodService.AddCookingMethodAsync(DTO);

        return Created(result.CookingMethodId, result);
    }

    [HttpPatch]
    public async Task<ActionResult<CookingMethodDTO>> Patch([FromBody]UpdateCookingMethodDTO DTO)
    {
        var result = await _cookingMethodService.UpdateCookingMethodAsync(DTO);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]DeleteCookingMethodDTO DTO)
    {
        await _cookingMethodService.DeleteCookingMethodAsync(DTO);

        return NoContent();
    }
}