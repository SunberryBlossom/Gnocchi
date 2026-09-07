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

    public Task<IReadOnlyList<DishDTO>> GetAllDishesAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<DishDTO> GetDishByIdAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<DishDTO> GetFullDishAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<DishDTO> UpdateDishAsync(UpdateDishDTO updateDishDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}