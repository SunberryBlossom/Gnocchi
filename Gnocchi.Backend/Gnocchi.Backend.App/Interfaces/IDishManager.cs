using Gnocchi.Backend.Models;
namespace Gnocchi.Backend.App.Services;

public interface IDishManager
{
    #region Create signatures
    public Task AddAsync(Dish dish, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<Dish?> GetByIdAsync(string id, CancellationToken ct = default);
    public Task<Dish?> GetCompleteByIdAsync(string id, CancellationToken ct = default);
    public Task<Dish?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<Dish?> UpdateAsync(string id, string attribute, string newValue, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task RemoveAsync(Dish dish);
    #endregion

}