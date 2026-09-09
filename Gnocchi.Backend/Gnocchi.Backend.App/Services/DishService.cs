using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Gnocchi.Backend.App.Services;

public class DishService : IDishService
{
    private readonly IDishManager _dishManager;
    private readonly IScoreManager _scoreManager;
    private readonly IVariantManager _variantManager;
    public DishService(IDishManager dishManager, IScoreManager scoreManager, IVariantManager variantManager)
    {
        _dishManager = dishManager;
        _scoreManager = scoreManager;
        _variantManager = variantManager;
    }
    public async Task<DishDTO> AddDishAsync(CreateDishDTO createDishDTO, CancellationToken ct = default)
    {
        var score = await _scoreManager.GetByIdAsync(createDishDTO.ScoreId, ct);
        var variant = await _variantManager.GetByIdAsync(createDishDTO.VariantId, ct);

        if (score is null || variant is null) // TODO: suboptimal, will iterate over one day.
        {
            throw new NullReferenceException(message: $"You have tried to enter a non existing score or variant into a dish!");
        }

        Dish dish = new()
        {
            DishId = Guid.NewGuid().ToString(),
            Name = createDishDTO.Name,
            VariantId = variant.VariantId,
            Variant = variant,
            ScoreId = score.ScoreId,
            Score = score,
            RecipeSteps = createDishDTO.RecipeStepIds.Select(id => new RecipeStep { RecipeStepId = id }).ToList()
        };

        await _dishManager.AddAsync(dish, ct);

        return new DishDTO
        {
            DishId = dish.DishId,
            Name = dish.Name,
            RecipeStepIds = dish.RecipeSteps?.Select(rs => rs.RecipeStepId ?? string.Empty).ToList() ?? new List<string>()
        };
    }

    public async Task DeleteDishAsync(DeleteDishDTO deleteDishDTO, CancellationToken ct = default)
    {
        var dishToBeDeleted = await _dishManager.GetByIdAsync(deleteDishDTO.DishId, ct);

        if (dishToBeDeleted is null)
        {
            throw new NullReferenceException(message: "Cannot delete a non existing dish!");
        }

        await _dishManager.RemoveAsync(dishToBeDeleted, ct);
    }

    public async Task<IReadOnlyList<DishDTO>> GetAllDishesAsync(CancellationToken ct = default)
    {
        var dishes = await _dishManager.GetAllAsync(ct);

        if (!dishes.Any())
        {
            return new List<DishDTO>();
        }

        return dishes.Select(dish => new DishDTO
        {
            DishId = dish.DishId ?? string.Empty,
            Name = dish.Name ?? string.Empty,
            RecipeStepIds = dish.RecipeSteps?.Select(rs => rs.RecipeStepId ?? string.Empty).ToList() ?? new List<string>()
        }).ToList();


    }

    public async Task<DishDTO> GetDishByIdAsync(string id, CancellationToken ct = default)
    {
        var dish = await _dishManager.GetByIdAsync(id, ct);

        if (dish is null)
        {
            throw new NullReferenceException(message: "this ID is not connected to any dish!");
        }

        return new DishDTO
        {
            DishId = dish.DishId ?? string.Empty,
            Name = dish.Name ?? string.Empty,
            RecipeStepIds = dish.RecipeSteps?.Select(rs => rs.RecipeStepId ?? string.Empty).ToList() ?? new List<string>()
        };
    }


    public async Task<DishDTO> UpdateDishAsync(UpdateDishDTO updateDishDTO, CancellationToken ct = default)
    {
        var dish = await _dishManager.GetByIdAsync(updateDishDTO.DishId, ct);

        if (dish is null)
        {
            throw new NullReferenceException(message: "this ID is not connected to any dish!");
        }

        await _dishManager.UpdateAsync(
            updateDishDTO.DishId,
            updateDishDTO.Attribute,
            updateDishDTO.NewValue,
            ct
        );


        return new DishDTO
        {
            DishId = dish.DishId ?? string.Empty,
            Name = dish.Name ?? string.Empty,
            RecipeStepIds = dish.RecipeSteps?.Select(rs => rs.RecipeStepId ?? string.Empty).ToList() ?? new List<string>()
        };
    }

    // TODO: try and find a case where this service method would actually be necessary... rn I think it is redundant.
    public Task<DishDTO> GetFullDishAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}