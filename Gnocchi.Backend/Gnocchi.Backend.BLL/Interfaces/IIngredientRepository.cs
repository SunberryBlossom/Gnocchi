namespace Gnocchi.Backend.Bll.Interfaces;

public interface IIngredientRepository
{
    #region Create signatures
    public Task AddAsync(Ingredient ingredient, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<Ingredient>> GetAllAsync(CancellationToken ct = default);
    public Task<Ingredient?> GetAsync(Guid id, CancellationToken ct = default);
    public Task<Ingredient?> GetFullAsync(Guid id, CancellationToken ct = default);
    public Task<Ingredient?> GetWithResultsAsync(Guid id, CancellationToken ct = default);
    public Task<Ingredient?> GetWithScoreAsync(Guid id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<Ingredient?> UpdateNameAsync(Guid id, string newName, CancellationToken ct = default);
    public Task<Ingredient?> UpdateRawEdibleAsync(Guid id, bool newEdibility, CancellationToken ct = default);
    public Task<Ingredient?> UpdateScoreAsync(Guid ingredientId, Guid newScoreId, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteAsync(Guid id, CancellationToken ct = default);
    #endregion
}