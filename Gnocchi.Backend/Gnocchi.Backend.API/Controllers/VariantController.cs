using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Gnocchi.Backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VariantsController : ControllerBase
{
    private readonly IVariantService _variantService;
    public VariantsController(IVariantService variantService)
    {
        _variantService = variantService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<VariantDTO>>> Get()
    {
        var variantDTOs = await _variantService.GetAllVariantsAsync();
        return Ok(variantDTOs);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<ActionResult<VariantDTO>> GetById([FromRoute]Guid id)
    {
        var variantDTO = await _variantService.GetVariantByIdAsync(id.ToString());

        if(variantDTO is null)
        {
            return NotFound();
        }
        
        return Ok(variantDTO);
    }

    [HttpPost]
    public async Task<ActionResult<VariantDTO>> Post([FromBody]CreateVariantDTO DTO)
    {
        var result = await _variantService.AddVariantAsync(DTO);

        return Created(result.VariantId, result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]DeleteVariantDTO DTO)
    {
        await _variantService.DeleteVariantAsync(DTO);

        return NoContent();
    }
}