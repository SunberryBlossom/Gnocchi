using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Gnocchi.Backend.App.Services;

public class ScoreService : IScoreService
{
    private readonly IScoreManager _scoreManager;
    public ScoreService(IScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }

    public async Task<ScoreDTO> AddScoreAsync(CreateScoreDTO createScoreDTO, CancellationToken ct = default)
    {
        Score score = new()
        {
            ScoreId = Guid.NewGuid().ToString(),
            Rating = createScoreDTO.Rating,
            Dishes = createScoreDTO.DishIds.Select(id => new Dish { DishId = id }).ToList(),
            CookingMethods = createScoreDTO.CookingMethodIds.Select(id => new CookingMethod { CookingMethodId = id }).ToList(),
            Ingredients = createScoreDTO.IngredientIds.Select(id => new Ingredient { IngredientId = id }).ToList()
        };
        
        await _scoreManager.AddAsync(score, ct);

        return new ScoreDTO
        {
            ScoreId = score.ScoreId,
            Rating = score.Rating,
            Dishes = score.Dishes?.Select(d => d.DishId ?? string.Empty).ToList() ?? new List<string>(),
            CookingMethods = score.CookingMethods?.Select(cm => cm.CookingMethodId ?? string.Empty).ToList() ?? new List<string>(),
            Ingredients = score.Ingredients?.Select(i => i.IngredientId ?? string.Empty).ToList() ?? new List<string>()
        };
    }

    public async Task DeleteScoreAsync(DeleteScoreDTO deleteScoreDTO, CancellationToken ct = default)
    {
        var score = await _scoreManager.GetByIdAsync(deleteScoreDTO.Id, ct);

        if (score is null)
        {
            throw new NullReferenceException(message: "This ID is not connected to any score!");
        }

        await _scoreManager.RemoveAsync(score, ct);
    }

    public async Task<IReadOnlyList<ScoreDTO>> GetAllScoresAsync(CancellationToken ct = default)
    {
        var scores = await _scoreManager.GetAllAsync(ct);

        if (scores is null || !scores.Any())
        {
            return new List<ScoreDTO>();
        }

        return scores.Select(score => new ScoreDTO
        {
            ScoreId = score.ScoreId ?? string.Empty,
            Rating = score.Rating,
            Dishes = score.Dishes?.Select(d => d.DishId ?? string.Empty).ToList() ?? new List<string>(),
            CookingMethods = score.CookingMethods?.Select(cm => cm.CookingMethodId ?? string.Empty).ToList() ?? new List<string>(),
            Ingredients = score.Ingredients?.Select(i => i.IngredientId ?? string.Empty).ToList() ?? new List<string>()
        }).ToList();
    }

    public async Task<ScoreDTO> GetScoreByIdAsync(string id, CancellationToken ct = default)
    {
        var score = await _scoreManager.GetByIdAsync(id, ct);

        if (score is null)
        {
            throw new NullReferenceException(message: "This ID does not belong to any score!");
        }

        return new ScoreDTO
        {
            ScoreId = score.ScoreId ?? string.Empty,
            Rating = score.Rating,
            Dishes = score.Dishes?.Select(d => d.DishId ?? string.Empty).ToList() ?? new List<string>(),
            CookingMethods = score.CookingMethods?.Select(cm => cm.CookingMethodId ?? string.Empty).ToList() ?? new List<string>(),
            Ingredients = score.Ingredients?.Select(i => i.IngredientId ?? string.Empty).ToList() ?? new List<string>()
        };
    }
}