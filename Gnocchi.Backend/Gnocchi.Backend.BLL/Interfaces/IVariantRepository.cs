namespace Gnocchi.Backend.Bll.Interfaces;

public interface IVariantRepository
{
    #region Create signatures
    public Task AddAsync(Variant variant, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<Variant>> GetAllAsync(CancellationToken ct = default);
    public Task<Result?> GetAsync(string id, CancellationToken ct = default);
    public Task<Result?> GetWithDishesAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    // None! If you update the enum field, you are essentially creating a new Variant, not updating it.
    #endregion
    #region Delete signatures
    public Task DeleteAsync(string id, CancellationToken ct = default);
    #endregion
}