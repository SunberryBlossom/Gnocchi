using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Services;

public class DishService : IDishService
{
    private readonly IDishManager _dishManager;
    public DishService(IDishManager dishManager)
    {
        _dishManager = dishManager;
    }
    public async Task<DishDTO> AddDishAsync(CreateDishDTO createDishDTO, CancellationToken ct = default)
    {
        Dish dish = new()
        {
            Name = createDishDTO.Name,
            Variant = createDishDTO.Variant,
            Score = createDishDTO.Score,
            RecipeSteps = createDishDTO.RecipeSteps
        };

        await _dishManager.AddAsync(dish, ct);

        return new DishDTO
        {
            DishId = dish.DishId!,
            Name = dish.Name,
            Variant = dish.Variant,
            Score = dish.Score,
            RecipeSteps = dish.RecipeSteps.ToList()
        };
    }

    public async Task DeleteDishAsync(DeleteDishDTO deleteDishDTO, CancellationToken ct = default)
    {
        var dishTobeDeleted = await _dishManager.GetByIdAsync(deleteDishDTO.DishId, ct);

        if (dishTobeDeleted is not null)
        {
            await _dishManager.RemoveAsync(dishTobeDeleted, ct);
        }
    }

    public async Task<IReadOnlyList<DishDTO>> GetAllDishesAsync(CancellationToken ct = default)
    {
        var result = await _dishManager.GetAllAsync(ct);
        return result.Select(dish => new DishDTO
        {
            DishId = dish.DishId,
            Name = dish.Name,
            Variant = dish.Variant,
            Score = dish.Score,
            RecipeSteps = dish.RecipeSteps.ToList()
        }).ToList();
    }

    public async Task<DishDTO> GetDishByIdAsync(string id, CancellationToken ct = default)
    {
        Dish? dish = await _dishManager.GetByIdAsync(id, ct);
        return new DishDTO
        {
            DishId = dish.DishId,
            Name = dish.Name,
            Score = dish.Score,
            RecipeSteps = dish.RecipeSteps.ToList()
        };
    }


    public async Task<DishDTO> UpdateDishAsync(UpdateDishDTO updateDishDTO, CancellationToken ct = default)
    {
        var dish = await _dishManager.UpdateAsync(
            updateDishDTO.Id,
            updateDishDTO.Attribute,
            updateDishDTO.NewValue, ct
        );

        return new DishDTO
        {
            DishId = dish.DishId,
            Name = dish.Name,
            Variant = dish.Variant,
            Score = dish.Score,
            RecipeSteps = dish.RecipeSteps.ToList()
        };
    }
    public Task<DishDTO> GetFullDishAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}