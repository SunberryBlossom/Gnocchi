namespace Gnocchi.Backend.Bll.Interfaces;

public interface IUserRepository
{
    #region Create signatures
    public Task AddAsync(User user, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<User>> GetAllAsync(CancellationToken ct = default);
    public Task<User?> GetAsync(Guid id, CancellationToken ct = default);
    public Task<User?> GetFullAsync(Guid id, CancellationToken ct = default);
    public Task<User?> GetWithSpecificEntitiesAsync(Guid id, CancellationToken ct = default, params int[] entities);
    #endregion
    #region Update signatures
    // None as of now; Identity most likely handles this, and if you wish to update another entity for a user, you should use that specific repository.
    #endregion
    #region Delete signatures
    public Task DeleteAsync(Guid id, CancellationToken ct = default);
    #endregion
}