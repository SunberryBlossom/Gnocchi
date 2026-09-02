namespace Gnocchi.Backend.Bll.Interfaces;

public interface IDishRepository
{
    #region Create signatures
    public Task AddAsync(Dish dish, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<Dish>> GetAllAsync(CancellationToken ct = default);
    public Task<Dish?> GetAsync(Guid id, CancellationToken ct = default);
    public Task<Dish?> GetFullAsync(Guid id, CancellationToken ct = default);
    public Task<Dish?> GetWithVariantAsync(Guid id, CancellationToken ct = default);
    public Task<Dish?> GetWithScoreAsync(Guid id, CancellationToken ct = default);
    public Task<Dish?> GetwithRecipeStepsAsync(Guid id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<Dish?> UpdateVariantAsync(Guid dishId, Guid newVariantId, CancellationToken ct = default);
    public Task<Dish?> UpdateScoreAsync(Guid dishId, Guid newScoreId, CancellationToken ct = default);
    public Task<Dish?> UpdateNameAsync(Guid id, string newName, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteAsync(Guid id, CancellationToken ct = default);
    #endregion
}