using Gnocchi.Backend.App.DTOs;

namespace Gnocchi.Backend.API.Interfaces;

public interface IDishService
{
    #region Create signatures
    public Task<DishDTO> AddDishAsync(CreateDishDTO createDishDTO, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<DishDTO> GetDishByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<DishDTO>> GetAllDishesAsync(CancellationToken ct = default);
    public Task<DishDTO> GetFullDishAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<DishDTO> UpdateDishAsync(UpdateDishDTO updateDishDTO, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteDishAsync(DeleteDishDTO deleteDishDTO, CancellationToken ct = default);
    #endregion
}