using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.BLL.Interfaces;

namespace Gnocchi.Backend.BLL.Managers;

public class VariantManager : IVariantManager
{
    #region Fields
    private readonly IVariantRepository _variantRepository;
    #endregion
    #region Constructors
    public VariantManager(IVariantRepository variantRepository)
    {
        _variantRepository = variantRepository;
    }
    #endregion
    #region Create methods
    public async void Add(Variant variant)
    {
        _variantRepository.Add(variant);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<Variant>?> GetAllAsync(CancellationToken ct = default)
    {
        return await _variantRepository.GetAllAsync(ct);
    }
    public async Task<Variant?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        return await _variantRepository.GetAsync(id, ct);
    }
    public async Task<Variant?> GetWithDishesAsync(string id, CancellationToken ct = default)
    {
        return await _variantRepository.GetWithDishesAsync(id, ct);
    }
    #endregion
    #region Update methods
    #endregion
    #region Delete methods
    public void Remove(Variant variant)
    {
        _variantRepository.Remove(variant);
    }
    #endregion
}