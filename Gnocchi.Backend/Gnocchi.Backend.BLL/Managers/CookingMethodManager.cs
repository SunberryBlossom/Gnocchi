using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.BLL.Interfaces;

namespace Gnocchi.Backend.BLL.Managers;

public class CookingMethodManager : ICookingMethodManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICookingMethodRepository _cookingMethodRepository;
    #endregion
    #region Constructors
    public CookingMethodManager(ICookingMethodRepository cookingMethodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _cookingMethodRepository = cookingMethodRepository;
    }
    #endregion
    #region Create methods
    public async Task AddAsync(CookingMethod cookingMethod, CancellationToken ct = default)
    {
        _cookingMethodRepository.Add(cookingMethod);
        await _unitOfWork.SaveChangesAsync(ct);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<CookingMethod>?> GetAllAsync(CancellationToken ct = default)
    {
        return await _cookingMethodRepository.GetAllAsync(ct);
    }
    public async Task<CookingMethod?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        return await _cookingMethodRepository.GetAsync(id, ct);
    }
    public async Task<CookingMethod?> GetCompleteByIdAsync(string id, CancellationToken ct = default)
    {
        return await _cookingMethodRepository.GetFullAsync(id, ct);
    }
    public async Task<CookingMethod?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default)
    {
        return entity switch
        {
            "score" => await _cookingMethodRepository.GetWithScoreAsync(id, ct),
            "result" => await _cookingMethodRepository.GetWithResultsAsync(id, ct),
            _ => null
        };
    }
    #endregion
    #region Update methods
    public async Task<CookingMethod?> UpdateScoreAsync(string id, string newValue, CancellationToken ct = default)
    {
        var result = await _cookingMethodRepository.UpdateScoreAsync(id, newValue, ct);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
    #endregion
    #region Delete methods
    public async Task RemoveAsync(CookingMethod cookingMethod, CancellationToken ct = default)
    {
        _cookingMethodRepository.Remove(cookingMethod);
        await _unitOfWork.SaveChangesAsync(ct);
    }
    #endregion
}