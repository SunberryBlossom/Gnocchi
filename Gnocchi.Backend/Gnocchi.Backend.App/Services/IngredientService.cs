using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientManager _ingredientManager;
    private readonly IScoreManager _scoreManager;

    public IngredientService(IIngredientManager ingredientManager, IScoreManager scoreManager)
    {
        _ingredientManager = ingredientManager;
        _scoreManager = scoreManager;
    }

    public async Task<IngredientDTO> AddIngredientAsync(CreateIngredientDTO createIngredientDTO, CancellationToken ct = default)
    {
        var score = await _scoreManager.GetByIdAsync(createIngredientDTO.ScoreId, ct);

        if (score is null)
        {
            throw new NullReferenceException(message: "This score is non existent!");
        }

        Ingredient ingredient = new()
        {
            IngredientId = Guid.NewGuid().ToString(),
            Name = createIngredientDTO.Name,
            EdibleRaw = createIngredientDTO.EdibleRaw,
            ScoreId = score.ScoreId,
            Score = score,
            Results = createIngredientDTO.Results
        };

        await _ingredientManager.AddAsync(ingredient, ct);

        return new IngredientDTO
        {
            IngredientId = ingredient.IngredientId,
            Name = ingredient.Name,
            EdibleRaw = ingredient.EdibleRaw,
            ScoreId = ingredient.ScoreId ??= string.Empty,
            Results = ingredient.Results
        };
    }

    public async Task DeleteIngredientAsync(DeleteIngredientDTO deleteIngredientDTO, CancellationToken ct = default)
    {
        var ingredientToBeDeleted = await _ingredientManager.GetByIdAsync(deleteIngredientDTO.IngredientId, ct);

        if (ingredientToBeDeleted is null)
        {
            throw new NullReferenceException(message: "this ID does not belong to any ingredient!");
        }

        await _ingredientManager.RemoveAsync(ingredientToBeDeleted, ct);
    }

    public async Task<IReadOnlyList<IngredientDTO>> GetAllIngredientsAsync(CancellationToken ct = default)
    {
        var ingredients = await _ingredientManager.GetAllAsync(ct);

        return ingredients.Select(ingredient => new IngredientDTO
        {
            IngredientId = ingredient.IngredientId!,
            Name = ingredient.Name ??= string.Empty,
            EdibleRaw = ingredient.EdibleRaw,
            ScoreId = ingredient.ScoreId ??= string.Empty,
            Results = ingredient.Results
        }).ToList();
    }

    public Task<IngredientDTO> GetIngredientByIdAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IngredientDTO> UpdateIngredientAsync(UpdateIngredientDTO updateIngredientDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}