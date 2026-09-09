using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Gnocchi.Backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DishesController : ControllerBase
{
private readonly IDishService _dishService;
    public DishesController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DishDTO>>> Get()
    {
        var dishDTOs = await _dishService.GetAllDishesAsync();
        return Ok(dishDTOs);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<ActionResult<DishDTO>> GetById([FromRoute]Guid id)
    {
        var dishDTO = await _dishService.GetDishByIdAsync(id.ToString());

        if(dishDTO is null)
        {
            return NotFound();
        }
        
        return Ok(dishDTO);
    }

    [HttpPost]
    public async Task<ActionResult<DishDTO>> Post([FromBody]CreateDishDTO DTO)
    {
        var dish = await _dishService.AddDishAsync(DTO);

        return CreatedAtAction(nameof(GetById), new { id = dish.DishId }, dish);
    }

    [HttpPatch]
    public async Task<ActionResult<DishDTO>> Patch([FromBody]UpdateDishDTO DTO)
    {
        var dish = await _dishService.UpdateDishAsync(DTO);
        return Ok(dish);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]DeleteDishDTO DTO)
    {
        await _dishService.DeleteDishAsync(DTO);

        return NoContent();
    }
}