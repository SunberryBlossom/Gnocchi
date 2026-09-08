using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Services;

public class CookingMethodService : ICookingMethodService
{
    private readonly ICookingMethodManager _cookingMethodManager;
    private readonly IScoreManager _scoreManager;
    public CookingMethodService(ICookingMethodManager cookingMethodManager, IScoreManager scoreManager)
    {
        _cookingMethodManager = cookingMethodManager;
        _scoreManager = scoreManager;
    }
    public async Task<CookingMethodDTO> AddCookingMethodAsync(CreateCookingMethodDTO createCookingMethodDTO, CancellationToken ct = default)
    {
        var score = await _scoreManager.GetByIdAsync(createCookingMethodDTO.ScoreId, ct);

        if (score is null)
        {
            throw new NullReferenceException(message: "The score is non existent!");
        }

        CookingMethod cookingMethod = new()
        {
            CookingMethodId = Guid.NewGuid().ToString(),
            Method = createCookingMethodDTO.Method,
            ScoreId = score.ScoreId,
            Score = score,
            Results = createCookingMethodDTO.Results
        };

        await _cookingMethodManager.AddAsync(cookingMethod, ct);

        return new CookingMethodDTO
        {
            CookingMethodId = cookingMethod.CookingMethodId,
            Method = cookingMethod.Method,
            ScoreId = cookingMethod.ScoreId ??= string.Empty,
            Results = cookingMethod.Results
        };
    }

    public async Task DeleteCookingMethodAsync(DeleteCookingMethodDTO deleteCookingMethodDTO, CancellationToken ct = default)
    {
        var cookingMethodToBeDeleted = await _cookingMethodManager.GetByIdAsync(deleteCookingMethodDTO.CookingMethodId, ct);

        if (cookingMethodToBeDeleted is null)
        {
            throw new NullReferenceException(message: "this cooking method does not exist!");
        }

        await _cookingMethodManager.RemoveAsync(cookingMethodToBeDeleted, ct);
    }

    public Task<IReadOnlyList<CookingMethodDTO>> GetAllCookingMethodsAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<CookingMethodDTO> GetCookingMethodByIdAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<CookingMethodDTO> UpdateCookingMethodAsync(UpdateCookingMethodDTO updateCookingMethodDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}