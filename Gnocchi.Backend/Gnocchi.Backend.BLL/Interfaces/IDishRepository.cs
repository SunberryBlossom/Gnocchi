namespace Gnocchi.Backend.Bll.Interfaces;

public interface IDishRepository
{
    #region Create signatures
    public Task AddAsync(Dish dish, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<Dish>> GetAllAsync(CancellationToken ct = default);
    public Task<Dish?> GetAsync(string id, CancellationToken ct = default);
    public Task<Dish?> GetFullAsync(string id, CancellationToken ct = default);
    public Task<Dish?> GetWithVariantAsync(string id, CancellationToken ct = default);
    public Task<Dish?> GetWithScoreAsync(string id, CancellationToken ct = default);
    public Task<Dish?> GetwithRecipeStepsAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<Dish?> UpdateVariantAsync(string dishId, string newVariantId, CancellationToken ct = default);
    public Task<Dish?> UpdateScoreAsync(string dishId, string newScoreId, CancellationToken ct = default);
    public Task<Dish?> UpdateNameAsync(string id, string newName, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteAsync(string id, CancellationToken ct = default);
    #endregion
}