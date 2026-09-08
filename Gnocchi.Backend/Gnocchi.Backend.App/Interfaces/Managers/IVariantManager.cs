using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Interfaces;

public interface IVariantManager
{
    #region Create signatures
    public void Add(Variant variant);
    #endregion
    #region Read signatures
    public Task<Variant?> GetByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<Variant>?> GetAllAsync(CancellationToken ct = default);
    public Task<Variant?> GetWithDishesAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    #endregion
    #region Delete signatures
    public void Remove(Variant variant);
    #endregion
}