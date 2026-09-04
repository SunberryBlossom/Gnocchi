using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Interfaces;

public interface ICookingMethodManager
{
    #region Create signatures
    public Task AddAsync(CookingMethod cookingMethod, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<CookingMethod>?> GetAllAsync(CancellationToken ct = default);
    public Task<CookingMethod?> GetByIdAsync(string id, CancellationToken ct = default);
    public Task<CookingMethod?> GetCompleteByIdAsync(string id, CancellationToken ct = default);
    public Task<CookingMethod?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<CookingMethod?> UpdateScoreAsync(string id, string newValue, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task RemoveAsync(CookingMethod cookingMethod, CancellationToken ct = default);
    #endregion
}