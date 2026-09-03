namespace Gnocchi.Backend.Bll.Interfaces;

public interface IUserRepository
{
    #region Create signatures
    public void Add(User user);
    #endregion
    #region Read signatures
    public Task<IReadOnlyList<User>> GetAllAsync(CancellationToken ct = default);
    public Task<User?> GetAsync(string id, CancellationToken ct = default);
    public Task<User?> GetFullAsync(string id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    // None as of now; Identity most likely handles this, and if you wish to update another entity for a user, you should use that specific repository.
    #endregion
    #region Delete signatures
    public void Remove(User user);
    #endregion
}