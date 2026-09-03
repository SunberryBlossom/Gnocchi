namespace Gnocchi.Backend.BLL.Interfaces;

public interface IVariantRepository
{
    #region Create signatures
    public void Add(Variant variant);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<Variant>> GetAllAsync(CancellationToken ct = default);
    public Task<Variant?> GetAsync(string id, CancellationToken ct = default);
    public Task<Variant?> GetWithDishesAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    // None! If you update the enum field, you are essentially creating a new Variant, not updating it.
    #endregion
    #region Delete signatures
    public void Remove(Variant variant);
    #endregion
}