using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;

namespace Gnocchi.Backend.App.Services;

public class DishService : IDishService
{
    public Task<DishDTO> AddDishAsync(CreateDishDTO createDishDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDishAsync(DeleteDishDTO deleteDishDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
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