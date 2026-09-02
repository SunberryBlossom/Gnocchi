namespace Gnocchi.Backend.Bll.Interfaces;

public interface IRecipeStepRepository // TODO: If time exists, check if repositories for junction tables are really a thing.
{
    #region Create signatures
    public Task AddAsync(RecipeStep recipeStep, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<RecipeStep>> GetAllAsync(CancellationToken ct = default);
    public Task<RecipeStep?> GetAsync(Guid id, CancellationToken ct = default);
    public Task<RecipeStep?> GetFullAsync(Guid id, CancellationToken ct = default);
    public Task<RecipeStep?> GetWithResultAsync(Guid id, CancellationToken ct = default);
    public Task<RecipeStep?> GetWithDishAsync(Guid id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    // None! Cannot see a reason to why a junction table should have to be updated
    #endregion
    #region Delete signatures
    public Task DeleteAsync(Guid id, CancellationToken ct = default);
    #endregion
}