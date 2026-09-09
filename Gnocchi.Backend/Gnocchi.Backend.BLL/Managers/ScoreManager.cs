using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.BLL.Interfaces;

namespace Gnocchi.Backend.BLL.Managers;

public class ScoreManager : IScoreManager
{
    #region Fields
    private readonly IScoreRepository _scoreRepository;
    private readonly IUnitOfWork _unitOfWork;
    #endregion
    #region Constructors
    public ScoreManager(IScoreRepository scoreRepository, IUnitOfWork unitOfWork)
    {
        _scoreRepository = scoreRepository;
        _unitOfWork = unitOfWork;
    }
    #endregion
    #region Create methods
    public async Task AddAsync(Score score, CancellationToken ct = default)
    {
        _scoreRepository.Add(score);
        await _unitOfWork.SaveChangesAsync(ct);
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
        await _unitOfWork.SaveChangesAsync(ct);
    }
    #endregion
}