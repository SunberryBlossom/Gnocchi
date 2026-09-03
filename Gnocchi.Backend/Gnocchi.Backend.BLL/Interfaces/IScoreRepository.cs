namespace Gnocchi.Backend.BLL.Interfaces;

public interface IScoreRepository
{
    #region Create signatures
    public void Add(Score score);
    #endregion
    #region Read signatures
    public Task<Score?> GetFullAsync(string id, CancellationToken ct = default);
    public Task<Score?> GetWithIngredientsAsync(string id, CancellationToken ct = default);
    public Task<Score?> GetWithCookingMethodAsync(string id, CancellationToken ct = default);
    public Task<Score?> GetWithDishesAsync(string id, CancellationToken ct = default);
    public Task<Score?> GetAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<Score>> GetAllAsync(CancellationToken ct = default);
    #endregion
    #region Update signatures
    // None! If a score is not to satisfaction, delete it and add a new one.
    #endregion
    #region Delete signatures
    public void Remove(Score score);
    #endregion
}