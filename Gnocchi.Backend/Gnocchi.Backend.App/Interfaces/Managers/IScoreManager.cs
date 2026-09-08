using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Interfaces;

public interface IScoreManager
{
    #region Create signatures
    public Task AddAsync(Score score, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<Score?> GetByIdAsync(string id, CancellationToken ct = default);
    public Task<Score?> GetCompleteByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<Score>?> GetAllAsync(CancellationToken ct = default);
    public Task<Score?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default);
    #endregion
    #region Update signatures
    #endregion
    #region Delete signatures
    public Task RemoveAsync(Score score, CancellationToken ct = default);
    #endregion
}