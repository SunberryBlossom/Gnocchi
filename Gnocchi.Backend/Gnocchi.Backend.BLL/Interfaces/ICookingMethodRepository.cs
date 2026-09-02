namespace Gnocchi.Backend.Bll.Interfaces;

public interface ICookingMethodRepository
{
    #region Create signatures
    public Task AddAsync(CookingMethod cookingMethod, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<CookingMethod>> GetAllAsync(CancellationToken ct = default);
    public Task<CookingMethod?> GetAsync(string id, CancellationToken ct = default);
    public Task<CookingMethod?> GetFullAsync(string id, CancellationToken ct = default);
    public Task<CookingMethod?> GetWithResultsAsync(string id, CancellationToken ct = default);
    public Task<CookingMethod?> GetWithScoreAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<CookingMethod?> UpdateScoreAsync(string cookingMethodId, string newScoreId, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteAsync(string id, CancellationToken ct = default);
    #endregion
}