using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.BLL.Interfaces;
using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.BLL.Managers;

public class RecipeStepManager : IRecipeStepManager
{
    #region Fields
    private readonly IRecipeStepRepository _recipeStepRepository;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Constructors
    public RecipeStepManager(IRecipeStepRepository recipeStepRepository, IUnitOfWork unitOfWork)
    {
        _recipeStepRepository = recipeStepRepository;
        _unitOfWork = unitOfWork;
    }
    #endregion

    #region Create methods
    public async Task AddAsync(RecipeStep recipeStep, CancellationToken ct = default)
    {
        _recipeStepRepository.Add(recipeStep);
        await _unitOfWork.SaveChangesAsync(ct);
    }
    #endregion

    #region Read methods
    public async Task<IReadOnlyList<RecipeStep>?> GetAllAsync(CancellationToken ct = default)
    {
        return await _recipeStepRepository.GetAllAsync(ct);
    }

    public async Task<RecipeStep?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        return await _recipeStepRepository.GetAsync(id, ct);
    }

    public async Task<RecipeStep?> GetCompleteByIdAsync(string id, CancellationToken ct = default)
    {
        return await _recipeStepRepository.GetFullAsync(id, ct);
    }

    public async Task<RecipeStep?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default)
    {
        return entity switch
        {
            "dish" => await _recipeStepRepository.GetWithDishAsync(id, ct),
            "result" => await _recipeStepRepository.GetWithResultAsync(id, ct),
            _ => null
        };
    }
    #endregion

    #region Delete methods
    public async Task RemoveAsync(RecipeStep recipeStep, CancellationToken ct = default)
    {
        _recipeStepRepository.Remove(recipeStep);
        await _unitOfWork.SaveChangesAsync(ct);
    }
    #endregion
}