namespace Gnocchi.Backend.Bll.Interfaces;

public interface IResultRepository
{
    #region Create signatures
    public Task AddAsync(Result result, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<Result>> GetAllAsync(CancellationToken ct = default);
    public Task<Result?> GetAsync(string id, CancellationToken ct = default);
    public Task<Result?> GetFullAsync(string id, CancellationToken ct = default);
    public Task<Result?> GetWithRecipeStepsAsync(string id, CancellationToken ct = default);
    public Task<Result?> GetWithCookingMethodAsync(string id, CancellationToken ct = default);
    public Task<Result?> GetWithIngredientAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<Result?> UpdateCommentAsync(string id, string newComment, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteAsync(string id, CancellationToken ct = default);
    #endregion
}