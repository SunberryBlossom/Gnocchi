using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Services;

public class RecipeStepService : IRecipeStepService
{
    private readonly IRecipeStepManager _recipeStepManager;
    private readonly IDishManager _dishManager;
    private readonly IResultManager _resultManager;

    public RecipeStepService
    (
        IRecipeStepManager recipeStepManager,
        IDishManager dishManager,
        IResultManager resultManager
    )
    {
        _recipeStepManager = recipeStepManager;
        _dishManager = dishManager;
        _resultManager = resultManager;
    }

    public async Task<RecipeStepDTO> AddRecipeStepAsync(CreateRecipeStepDTO createRecipeStepDTO, CancellationToken ct = default)
    {
        var dish = await _dishManager.GetByIdAsync(createRecipeStepDTO.DishId, ct);
        var result = await _resultManager.GetByIdAsync(createRecipeStepDTO.ResultId, ct);

        if (dish is null || result is null)
        {
            throw new NullReferenceException(message: "Either Dish or Result does not exist!");
        }

        RecipeStep recipeStep = new()
        {
            RecipeStepId = Guid.NewGuid().ToString(),
            DishId = dish.DishId,
            Dish = dish,
            ResultId = result.ResultId,
            Result = result
        };

        await _recipeStepManager.AddAsync(recipeStep, ct);

        return new RecipeStepDTO
        {
            RecipeStepId = recipeStep.RecipeStepId,
            DishId = recipeStep.DishId,
            ResultId = recipeStep.ResultId
        };
    }

    public async Task DeleteRecipeStepAsync(DeleteRecipeStepDTO deleteRecipeStepDTO, CancellationToken ct = default)
    {
        var stepToBeDeleted = await _recipeStepManager.GetByIdAsync(deleteRecipeStepDTO.RecipeStepId, ct);

        if (stepToBeDeleted is null)
        {
            throw new NullReferenceException(message: "This RecipeStep does not exist!");
        }

        await _recipeStepManager.RemoveAsync(stepToBeDeleted, ct);
    }

    public async Task<IReadOnlyList<RecipeStepDTO>> GetAllRecipeStepsAsync(CancellationToken ct = default)
    {
        var steps = await _recipeStepManager.GetAllAsync(ct);

        if (steps is null)
        {
            return new List<RecipeStepDTO>();
        }

        return steps.Select(step => new RecipeStepDTO
        {
            RecipeStepId = step.RecipeStepId ?? string.Empty,
            DishId = step.DishId ?? string.Empty,
            ResultId = step.ResultId ?? string.Empty
        }).ToList();
    }

    public async Task<RecipeStepDTO> GetRecipeStepByIdAsync(string id, CancellationToken ct = default)
    {
        var step = await _recipeStepManager.GetByIdAsync(id, ct);

        if (step is null)
        {
            throw new NullReferenceException(message: "This ID is not connected to any RecipeStep!");
        }

        return new RecipeStepDTO
        {
            RecipeStepId = step.RecipeStepId ?? string.Empty,
            DishId = step.DishId ?? string.Empty,
            ResultId = step.ResultId ?? string.Empty
        };
    }
}