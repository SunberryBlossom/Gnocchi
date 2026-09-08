using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Interfaces;

public interface IResultManager
{
    #region Create signatures
    public Task AddAsync(Result result, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<Result?> GetByIdAsync(string id, CancellationToken ct = default);
    public Task<Result?> GetCompleteByIdAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<Result>?> GetAllAsync(CancellationToken ct = default);
    public Task<Result?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<Result?> UpdateCommentAsync(string id, string newValue, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task RemoveAsync(Result result, CancellationToken ct = default);
    #endregion
}