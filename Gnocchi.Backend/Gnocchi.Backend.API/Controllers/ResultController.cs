using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Gnocchi.Backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResultsController : ControllerBase
{
    private readonly IResultService _resultService;
    public ResultsController(IResultService resultService)
    {
        _resultService = resultService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ResultDTO>>> Get()
    {
        var resultDTOs = await _resultService.GetAllResultsAsync();
        if (!resultDTOs.Any())
        {
            return NotFound();
        }

        return Ok(resultDTOs);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<ActionResult<ResultDTO>> GetById([FromRoute]Guid id)
    {
        var resultDTO = await _resultService.GetResultByIdAsync(id.ToString());

        if(resultDTO is null)
        {
            return NotFound();
        }
        
        return Ok(resultDTO);
    }

    [HttpPost]
    public async Task<ActionResult<ResultDTO>> Post([FromBody]CreateResultDTO DTO)
    {
        var result = await _resultService.AddResultAsync(DTO);

        return Created(result.ResultId, result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]DeleteResultDTO DTO)
    {
        await _resultService.DeleteResultAsync(DTO);

        return NoContent();
    }
}