namespace Gnocchi.Backend.Bll.Interfaces;

public interface ICookingMethodRepository
{
    #region Create signatures
    public Task AddAsync(CookingMethod cookingMethod, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<CookingMethod>> GetAllAsync(CancellationToken ct = default);
    public Task<CookingMethod?> GetAsync(Guid id, CancellationToken ct = default);
    public Task<CookingMethod?> GetFullAsync(Guid id, CancellationToken ct = default);
    public Task<CookingMethod?> GetWithResultsAsync(Guid id, CancellationToken ct = default);
    public Task<CookingMethod?> GetWithScoreAsync(Guid id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<CookingMethod?> UpdateScoreAsync(Guid cookingMethodId, Guid newScoreId, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteAsync(Guid id, CancellationToken ct = default);
    #endregion
}