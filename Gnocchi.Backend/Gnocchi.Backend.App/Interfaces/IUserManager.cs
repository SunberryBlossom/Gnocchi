using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Interfaces;

public interface IUserManager
{
    #region Create signatures
    public Task AddAsync(User user, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<User?> GetAsync(string id, CancellationToken ct = default);
    public Task<User?> GetCompleteAsync(string id, CancellationToken ct = default);
    public Task<IReadOnlyList<User>?> GetAllAsync(CancellationToken ct = default);
    #endregion
    #region Update signatures
    #endregion
    #region Delete signatures
    public Task RemoveAsync(User user, CancellationToken ct = default);
    #endregion
}