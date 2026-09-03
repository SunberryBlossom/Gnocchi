namespace Gnocchi.Backend.BLL.Interfaces;

public interface IRecipeStepRepository // TODO: If time exists, check if repositories for junction tables are really a thing.
{
    #region Create signatures
    public void Add(RecipeStep recipeStep);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<RecipeStep>> GetAllAsync(CancellationToken ct = default);
    public Task<RecipeStep?> GetAsync(string id, CancellationToken ct = default);
    public Task<RecipeStep?> GetFullAsync(string id, CancellationToken ct = default);
    public Task<RecipeStep?> GetWithResultAsync(string id, CancellationToken ct = default);
    public Task<RecipeStep?> GetWithDishAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    // None! Cannot see a reason to why a junction table should have to be updated
    #endregion
    #region Delete signatures
    public void Remove(RecipeStep recipeStep);
    #endregion
}