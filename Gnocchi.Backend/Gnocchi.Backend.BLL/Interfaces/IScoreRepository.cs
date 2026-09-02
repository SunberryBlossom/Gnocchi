namespace Gnocchi.Backend.Bll.Interfaces;

public interface IScoreRepository
{
    #region Create signatures
    public Task AddAsync(Score score, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<Score?> GetFullAsync(Guid id, CancellationToken ct = default);
    public Task<Score?> GetWithIngredientsAsync(Guid id, CancellationToken ct = default);
    public Task<Score?> GetWithCookingMethodAsync(Guid id, CancellationToken ct = default);
    public Task<Score> GetWithDishesAsync(Guid id, CancellationToken ct = default);
    public Task<Score?> GetAsync(Guid id, CancellationToken ct = default);
    public Task<IReadOnlyList<Score>> GetAllAsync(CancellationToken ct = default);
    #endregion
    #region Update signatures
    // None! If a score is not to satisfaction, delete it and add a new one.
    #endregion
    #region Delete signatures
    public Task DeleteAsync(Guid id, CancellationToken ct = default);
    #endregion
}