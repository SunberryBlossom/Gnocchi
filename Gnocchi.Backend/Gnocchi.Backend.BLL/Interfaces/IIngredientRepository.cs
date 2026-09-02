namespace Gnocchi.Backend.Bll.Interfaces;

public interface IIngredientRepository
{
    #region Create signatures
    public Task AddAsync(Ingredient ingredient, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<Ingredient>> GetAllAsync(CancellationToken ct = default);
    public Task<Ingredient?> GetAsync(string id, CancellationToken ct = default);
    public Task<Ingredient?> GetFullAsync(string id, CancellationToken ct = default);
    public Task<Ingredient?> GetWithResultsAsync(string id, CancellationToken ct = default);
    public Task<Ingredient?> GetWithScoreAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<Ingredient?> UpdateNameAsync(string id, string newName, CancellationToken ct = default);
    public Task<Ingredient?> UpdateRawEdibleAsync(string id, bool newEdibility, CancellationToken ct = default);
    public Task<Ingredient?> UpdateScoreAsync(string ingredientId, string newScoreId, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteAsync(string id, CancellationToken ct = default);
    #endregion
}