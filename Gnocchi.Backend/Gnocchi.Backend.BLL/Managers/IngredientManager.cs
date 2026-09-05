using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.BLL.Interfaces;

namespace Gnocchi.Backend.BLL.Managers;

public class IngredientManager : IIngredientManager
{
    #region Fields
    private readonly IIngredientRepository _ingredientRepository;
    #endregion
    #region Constructors
    public IngredientManager(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    #endregion
    #region Create methods
    public async Task AddAsync(Ingredient ingredient, CancellationToken ct = default)
    {
        _ingredientRepository.Add(ingredient);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<Ingredient>> GetAllAsync(CancellationToken ct = default)
    {
        return await _ingredientRepository.GetAllAsync(ct);
    }
    public async Task<Ingredient?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        return await _ingredientRepository.GetAsync(id, ct);
    }
    public async Task<Ingredient?> GetCompleteByIdAsync(string id, CancellationToken ct = default)
    {
        return await _ingredientRepository.GetFullAsync(id, ct);
    }
    public async Task<Ingredient?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default)
    {
        return entity switch
        {
            "score" => await _ingredientRepository.GetWithScoreAsync(id, ct),
            "results" => await _ingredientRepository.GetWithResultsAsync(id, ct),
            _ => null
        };
    }
    #endregion
    #region Update methods
    public async Task<Ingredient?> UpdateAsync(string id, string attribute, string newValue, CancellationToken ct = default)
    {
        var result = attribute switch
        {
            "name" => await _ingredientRepository.UpdateNameAsync(id, newValue, ct),
            "variant" => await _ingredientRepository.UpdateRawEdibleAsync(id, bool.Parse(newValue), ct),
            "score" => await _ingredientRepository.UpdateScoreAsync(id, newValue, ct),
            _ => null
        };
        return result;
    }
    #endregion
    #region Delete methods
    public async Task RemoveAsync(Ingredient ingredient, CancellationToken ct = default)
    {
        _ingredientRepository.Remove(ingredient);
    }
    #endregion
}