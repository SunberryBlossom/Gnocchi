using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.BLL.Interfaces;

namespace Gnocchi.Backend.BLL.Managers;

public class ResultManager : IResultManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IResultRepository _resultRepository;
    #endregion
    #region Constructors
    public ResultManager(IResultRepository resultRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _resultRepository = resultRepository;
    }
    #endregion
    #region Create methods
    public async Task AddAsync(Result result, CancellationToken ct = default)
    {
        _resultRepository.Add(result);
        await _unitOfWork.SaveChangesAsync(ct);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<Result>?> GetAllAsync(CancellationToken ct = default)
    {
        return await _resultRepository.GetAllAsync(ct);
    }
    public async Task<Result?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        return await _resultRepository.GetAsync(id, ct);
    }
    public async Task<Result?> GetCompleteByIdAsync(string id, CancellationToken ct = default)
    {
        return await _resultRepository.GetFullAsync(id, ct);
    }
    public async Task<Result?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default)
    {
        return entity switch
        {
            "cookingmethod" => await _resultRepository.GetWithCookingMethodAsync(id, ct),
            "ingredient" => await _resultRepository.GetWithIngredientAsync(id, ct),
            "recipesteps" => await _resultRepository.GetWithRecipeStepsAsync(id, ct),
            _ => null
        };
    }
    #endregion
    #region Update methods
    public async Task<Result?> UpdateCommentAsync(string id, string newValue, CancellationToken ct = default)
    {
        var result = await _resultRepository.UpdateCommentAsync(id, newValue, ct);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
    #endregion
    #region Delete methods
    public async Task RemoveAsync(Result result, CancellationToken ct = default)
    {
        _resultRepository.Remove(result);
        await _unitOfWork.SaveChangesAsync(ct);
    }
    #endregion
}