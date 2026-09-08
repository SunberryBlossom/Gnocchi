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
            Dishes = createScoreDTO.Dishes,
            CookingMethods = createScoreDTO.CookingMethods,
            Ingredients = createScoreDTO.Ingredients
        };
        
        await _scoreManager.AddAsync(score, ct);

        return new ScoreDTO
        {
            ScoreId = score.ScoreId,
            Rating = score.Rating,
            Dishes = score.Dishes,
            CookingMethods = score.CookingMethods,
            Ingredients = score.Ingredients
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

        if (!scores.Any())
        {
            return new List<ScoreDTO>();
        }

        return scores.Select(score => new ScoreDTO
        {
            ScoreId = score.ScoreId,
            Rating = score.Rating,
            Dishes = score.Dishes,
            CookingMethods = score.CookingMethods,
            Ingredients = score.Ingredients
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
            ScoreId = score.ScoreId!,
            Rating = score.Rating,
            Dishes = score.Dishes ??= new List<Dish>(),
            CookingMethods = score.CookingMethods ??= new List<CookingMethod>() ,
            Ingredients = score.Ingredients ??= new List<Ingredient>()
        };
    }
}