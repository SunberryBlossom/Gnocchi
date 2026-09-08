using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Interfaces;

public interface IIngredientManager
{
    #region Create signatures
    public Task AddAsync(Ingredient ingredient, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<Ingredient?> GetByIdAsync(string id, CancellationToken ct = default);
    public Task<Ingredient?> GetCompleteByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<Ingredient>> GetAllAsync(CancellationToken ct = default);
    public Task<Ingredient?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<Ingredient?> UpdateAsync(string id, string attribute, string newValue, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task RemoveAsync(Ingredient ingredient, CancellationToken ct = default);
    #endregion
}