using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.BLL.Interfaces;

namespace Gnocchi.Backend.BLL.Managers;

public class VariantManager : IVariantManager
{
    #region Fields
    private readonly IVariantRepository _variantRepository;
    private readonly IUnitOfWork _unitOfWork;
    #endregion
    #region Constructors
    public VariantManager(IVariantRepository variantRepository, IUnitOfWork unitOfWork)
    {
        _variantRepository = variantRepository;
        _unitOfWork = unitOfWork;
    }
    #endregion
    #region Create methods
    public async Task AddAsync(Variant variant, CancellationToken ct = default)
    {
        _variantRepository.Add(variant);
        await _unitOfWork.SaveChangesAsync(ct);
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
    public async Task RemoveAsync(Variant variant, CancellationToken ct = default)
    {
        _variantRepository.Remove(variant);
        await _unitOfWork.SaveChangesAsync(ct);
    }
    #endregion
}