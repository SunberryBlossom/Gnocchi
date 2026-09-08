using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;

namespace Gnocchi.Backend.App.Services;

public class ResultService : IResultService
{
    private readonly IResultManager _resultManager;
    private readonly IIngredientManager _ingredientManager;
    private readonly ICookingMethodManager _cookingMethodManager;
    public ResultService
    (
        IResultManager resultManager,
        IIngredientManager ingredientManager,
        ICookingMethodManager cookingMethodManager
    )
    {
        _resultManager = resultManager;
        _ingredientManager = ingredientManager;
        _cookingMethodManager = cookingMethodManager;
    }
    public Task<ResultDTO> AddResultAsync(CreateResultDTO createResultDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteResultAsync(DeleteResultDTO deleteResultDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<ResultDTO>> GetAllResultsAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDTO> GetResultByIdAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDTO> UpdateResultAsync(UpdateResultDTO updateResultDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}