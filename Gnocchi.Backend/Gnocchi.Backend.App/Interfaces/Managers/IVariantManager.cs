using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Interfaces;

public interface IVariantManager
{
    #region Create signatures
    public Task AddAsync(Variant variant, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<Variant?> GetByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<Variant>?> GetAllAsync(CancellationToken ct = default);
    public Task<Variant?> GetWithDishesAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    #endregion
    #region Delete signatures
    public Task RemoveAsync(Variant variant, CancellationToken ct = default);
    #endregion
}