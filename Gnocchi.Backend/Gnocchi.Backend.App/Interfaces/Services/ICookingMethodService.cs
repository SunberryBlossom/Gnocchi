using Gnocchi.Backend.App.DTOs;

namespace Gnocchi.Backend.API.Interfaces;

public interface ICookingMethodService
{
    #region Create signatures
    public Task<CookingMethodDTO> AddCookingMethodAsync(CreateCookingMethodDTO createCookingMethodDTO, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<CookingMethodDTO> GetCookingMethodByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<CookingMethodDTO>> GetAllCookingMethodsAsync(CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<CookingMethodDTO> UpdateCookingMethodAsync(UpdateCookingMethodDTO updateCookingMethodDTO, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteCookingMethodAsync(DeleteCookingMethodDTO deleteCookingMethodDTO, CancellationToken ct = default);
    #endregion
}