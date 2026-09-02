namespace Gnocchi.Backend.Bll.Interfaces;

public interface ICookingMethodRepository
{
    #region Create signatures
    public Task AddAsync(CookingMethod cookingMethod, CancellationToken ct = default);
    #endregion
    #region Read signatures
    public Task<CookingMethod?> GetWithMethodAsync(Guid id, CancellationToken ct = default);
    #endregion
    #region Update signatures
    public Task<CookingMethod?> UpdateScoreAsync(Guid cookingMethodId, Guid scoreId, CancellationToken ct = default);
    #endregion
    #region Delete signatures
    public Task DeleteAsync(Guid id, CancellationToken ct = default);
    #endregion
}