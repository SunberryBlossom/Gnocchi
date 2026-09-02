namespace Gnocchi.Backend.Bll.Interfaces;

public interface IResultRepository
{
    #region Create signatures
    public Task AddAsync(Result result, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<Result>> GetAllAsync(CancellationToken ct = default);
    public Task<Result?> GetAsync(Guid id, CancellationToken ct = default);
    public Task<Result?> GetFullAsync(Guid id, CancellationToken ct = default);
    public Task<Result?> GetWithRecipeStepsAsync(Guid id, CancellationToken ct = default);
    public Task<Result?> GetWithCookingMethodAsync(Guid id, CancellationToken ct = default);
    public Task<Result?> GetWithIngredientAsync(Guid id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<Result?> UpdateCommentAsync(Guid id, string newComment, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteAsync(Guid id, CancellationToken ct = default);
    #endregion
}