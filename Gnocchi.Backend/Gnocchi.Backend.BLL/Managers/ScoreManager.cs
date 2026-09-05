using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.BLL.Interfaces;

namespace Gnocchi.Backend.BLL.Managers;

public class ScoreManager : IScoreManager
{
    #region Fields
    private readonly IScoreRepository _scoreRepository;
    #endregion
    #region Constructors
    public ScoreManager(IScoreRepository scoreRepository)
    {
        _scoreRepository = scoreRepository;
    }
    #endregion
    #region Create methods
    public async Task AddAsync(Score score, CancellationToken ct = default)
    {
        _scoreRepository.Add(score);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<Score>?> GetAllAsync(CancellationToken ct = default)
    {
        return await _scoreRepository.GetAllAsync(ct);
    }

    public async Task<Score?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        return await _scoreRepository.GetAsync(id, ct);
    }

    public async Task<Score?> GetCompleteByIdAsync(string id, CancellationToken ct = default)
    {
        return await _scoreRepository.GetFullAsync(id, ct);
    }

    public async Task<Score?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default)
    {
        return entity switch
        {
            "cookingmethod" => await _scoreRepository.GetWithCookingMethodsAsync(id, ct),
            "ingredients" => await _scoreRepository.GetWithIngredientsAsync(id, ct),
            "dishes" => await _scoreRepository.GetWithDishesAsync(id, ct),
            _ => null
        };
    }
    #endregion
    #region Update methods
    #endregion
    #region Delete methods
    public async Task RemoveAsync(Score score, CancellationToken ct = default)
    {
        _scoreRepository.Remove(score);
    }
    #endregion
}