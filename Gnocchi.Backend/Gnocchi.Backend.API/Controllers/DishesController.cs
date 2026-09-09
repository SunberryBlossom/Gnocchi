using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gnocchi.Backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
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
        if (!dishDTOs.Any())
        {
            return NotFound();
        }

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

        return Created(dish.DishId, dish);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]DeleteDishDTO DTO)
    {
        await _dishService.DeleteDishAsync(DTO);

        return NoContent();
    }
}