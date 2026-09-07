using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.Models;

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
            throw new NullReferenceException(message: $"You have tried to enter a non existing score or variant!");
        }

        Dish dish = new()
        {
            DishId = Guid.NewGuid().ToString(),
            Name = createDishDTO.Name,
            VariantId = variant.VariantId,
            Variant = variant,
            ScoreId = score.ScoreId,
            Score = score,
            RecipeSteps = createDishDTO.RecipeSteps
        };

        await _dishManager.AddAsync(dish, ct);

        return new DishDTO
        {
            DishId = dish.DishId,
            Name = dish.Name,
            VariantId = dish.VariantId,
            ScoreId = dish.ScoreId,
            RecipeSteps = dish.RecipeSteps.ToList()
        };
    }

    public async Task DeleteDishAsync(DeleteDishDTO deleteDishDTO, CancellationToken ct = default)
    {
    }

    public async Task<IReadOnlyList<DishDTO>> GetAllDishesAsync(CancellationToken ct = default)
    {
    }

    public async Task<DishDTO> GetDishByIdAsync(string id, CancellationToken ct = default)
    {
    }


    public async Task<DishDTO> UpdateDishAsync(UpdateDishDTO updateDishDTO, CancellationToken ct = default)
    {
    }
    public Task<DishDTO> GetFullDishAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}