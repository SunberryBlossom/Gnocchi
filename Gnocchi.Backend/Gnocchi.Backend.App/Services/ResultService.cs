using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.Models;

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
    public async Task<ResultDTO> AddResultAsync(CreateResultDTO createResultDTO, CancellationToken ct = default)
    {
        var ingredient = await _ingredientManager.GetByIdAsync(createResultDTO.IngredientId, ct);
        var cookingMethod = await _cookingMethodManager.GetByIdAsync(createResultDTO.CookingMethodId, ct);

        if (ingredient is null || cookingMethod is null)
        {
            throw new NullReferenceException(message: "either the ingredient or cookingmethod is non existent!");
        }

        Result result = new()
        {
            ResultId = Guid.NewGuid().ToString(),
            Comment = createResultDTO.Comment,
            IngredientId = ingredient.IngredientId,
            Ingredient = ingredient,
            CookingMethodId = cookingMethod.CookingMethodId,
            CookingMethod = cookingMethod,
            RecipeSteps = createResultDTO.RecipeSteps
        };

        await _resultManager.AddAsync(result, ct);

        return new ResultDTO
        {
            ResultId = result.ResultId,
            Comment = result.Comment,
            IngredientId = result.IngredientId ??= string.Empty,
            CookingMethodId = result.CookingMethodId ??= string.Empty,
            RecipeSteps = result.RecipeSteps.ToList()
        };
    }

    public async Task DeleteResultAsync(DeleteResultDTO deleteResultDTO, CancellationToken ct = default)
    {
        var resultToBeDeleted = await _resultManager.GetByIdAsync(deleteResultDTO.ResultId, ct);

        if (resultToBeDeleted is null)
        {
            throw new NullReferenceException(message: "This Result does not exist!");
        }

        await _resultManager.RemoveAsync(resultToBeDeleted, ct);
    }

    public async Task<IReadOnlyList<ResultDTO>> GetAllResultsAsync(CancellationToken ct = default)
    {
        var results = await _resultManager.GetAllAsync(ct);

        if (results is null)
        {
            return new List<ResultDTO>();
        }

        return results.Select(result => new ResultDTO
        {
            ResultId = result.ResultId!,
            Comment = result.Comment ??= string.Empty,
            IngredientId = result.IngredientId!,
            CookingMethodId = result.CookingMethodId!,
            RecipeSteps = result.RecipeSteps.ToList() ?? new List<RecipeStep>()
        }).ToList();
    }

    public async Task<ResultDTO> GetResultByIdAsync(string id, CancellationToken ct = default)
    {
        var result = await _resultManager.GetByIdAsync(id, ct);

        if (result is null)
        {
            throw new NullReferenceException(message: "this ID is not connected to any result!");
        }

        return new ResultDTO
        {
            ResultId = result.ResultId!,
            Comment = result.Comment ??= string.Empty,
            IngredientId = result.IngredientId!,
            CookingMethodId = result.CookingMethodId!,
            RecipeSteps = result.RecipeSteps.ToList() ?? new List<RecipeStep>()
        };
    }

    public async Task<ResultDTO> UpdateResultAsync(UpdateResultDTO updateResultDTO, CancellationToken ct = default)
    {
        var result = await _resultManager.GetByIdAsync(updateResultDTO.ResultId, ct);

        if (result is null)
        {
            throw new NullReferenceException(message: "this ID is not connected to any result!");
        }

        await _resultManager.UpdateCommentAsync(
            updateResultDTO.ResultId,
            updateResultDTO.NewValue,
            ct
        );

        return new ResultDTO
        {
            ResultId = result.ResultId!,
            Comment = result.Comment ??= string.Empty,
            IngredientId = result.IngredientId!,
            CookingMethodId = result.CookingMethodId!,
            RecipeSteps = result.RecipeSteps.ToList() ?? new List<RecipeStep>()
        };
    }
}