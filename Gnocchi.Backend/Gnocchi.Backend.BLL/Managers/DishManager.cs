using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.BLL.Interfaces;
namespace Gnocchi.Backend.BLL.Managers;

public class DishManager : IDishManager
{
    #region Fields
    private readonly IDishRepository _dishRepository;
    private readonly IUnitOfWork _unitOfWork;
    #endregion
    #region Constructors
    public DishManager(IDishRepository dishRepository, IUnitOfWork unitOfWork)
    {
        _dishRepository = dishRepository;
        _unitOfWork = unitOfWork;
    }
    #endregion
    #region Create methods
    public async Task AddAsync(Dish dish, CancellationToken ct = default)
    {
        _dishRepository.Add(dish);
        await _unitOfWork.SaveChangesAsync();
    }
    #endregion
    #region Read methods
    public async Task<Dish?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        return await _dishRepository.GetAsync(id, ct);
    }
    public async Task<IReadOnlyList<Dish>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dishRepository.GetAllAsync(ct);
    }
    public async Task<Dish?> GetCompleteByIdAsync(string id, CancellationToken ct = default)
    {
        return await _dishRepository.GetFullAsync(id, ct);
    }
    public async Task<Dish?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default)
    {
        return entity switch
        {
            "score" => await _dishRepository.GetWithScoreAsync(id, ct),
            "recipesteps" => await _dishRepository.GetwithRecipeStepsAsync(id, ct),
            "variant" => await _dishRepository.GetWithVariantAsync(id, ct),
            _ => null
        };
    }
    #endregion
    #region Update methods
    public async Task<Dish?> UpdateAsync(string id, string attribute, string newValue, CancellationToken ct = default)
    {
        var result = attribute switch
        {
            "name" => await _dishRepository.UpdateNameAsync(id, newValue, ct),
            "variant" => await _dishRepository.UpdateVariantAsync(id, newValue, ct),
            "score" => await _dishRepository.UpdateScoreAsync(id, newValue, ct),
            _ => null
        };
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
    #endregion
    #region Delete methods
    public async Task RemoveAsync(Dish dish)
    {
        _dishRepository.Remove(dish);
        await _unitOfWork.SaveChangesAsync();
    }
    #endregion
}