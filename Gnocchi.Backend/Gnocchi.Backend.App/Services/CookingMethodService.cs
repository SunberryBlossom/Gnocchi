using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
            Results = createCookingMethodDTO.ResultIds.Select(id => new Result { ResultId = id }).ToList()
        };

        await _cookingMethodManager.AddAsync(cookingMethod, ct);

        return new CookingMethodDTO
        {
            CookingMethodId = cookingMethod.CookingMethodId,
            Method = cookingMethod.Method,
            Results = cookingMethod.Results?.Select(r => r.ResultId ?? string.Empty).ToList() ?? new List<string>()
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

    public async Task<IReadOnlyList<CookingMethodDTO>> GetAllCookingMethodsAsync(CancellationToken ct = default)
    {
        var cookingMethods = await _cookingMethodManager.GetAllAsync(ct);

        if (cookingMethods is null || !cookingMethods.Any())
        {
            return new List<CookingMethodDTO>();
        }

        return cookingMethods.Select(cookingMethod => new CookingMethodDTO
        {
            CookingMethodId = cookingMethod.CookingMethodId ?? string.Empty,
            Method = cookingMethod.Method,
            Results = cookingMethod.Results?.Select(r => r.ResultId ?? string.Empty).ToList() ?? new List<string>()
        }).ToList();
    }

    public async Task<CookingMethodDTO> GetCookingMethodByIdAsync(string id, CancellationToken ct = default)
    {
        var cookingMethod = await _cookingMethodManager.GetByIdAsync(id, ct);

        if (cookingMethod is null)
        {
            throw new NullReferenceException(message: "this CookingMethod does not exist!");
        }

        return new CookingMethodDTO
        {
            CookingMethodId = cookingMethod.CookingMethodId ?? string.Empty,
            Method = cookingMethod.Method,
            Results = cookingMethod.Results?.Select(r => r.ResultId ?? string.Empty).ToList() ?? new List<string>()
        };
    }

    public async Task<CookingMethodDTO> UpdateCookingMethodAsync(UpdateCookingMethodDTO updateCookingMethodDTO, CancellationToken ct = default)
    {
        var cookingMethod = await _cookingMethodManager.GetByIdAsync(updateCookingMethodDTO.CookingMethodId, ct);

        if (cookingMethod is null)
        {
            throw new NullReferenceException(message: "this ID is not connected to any cookingMethod!");
        }

        await _cookingMethodManager.UpdateScoreAsync(
            updateCookingMethodDTO.CookingMethodId,
            updateCookingMethodDTO.ScoreId,
            ct
        );


        return new CookingMethodDTO
        {
            CookingMethodId = cookingMethod.CookingMethodId ?? string.Empty,
            Method = cookingMethod.Method,
            Results = cookingMethod.Results?.Select(r => r.ResultId ?? string.Empty).ToList() ?? new List<string>()
        };
    }
}