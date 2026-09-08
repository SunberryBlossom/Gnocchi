using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;

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
    public Task<CookingMethodDTO> AddCookingMethodAsync(CreateCookingMethodDTO createCookingMethodDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCookingMethodAsync(DeleteCookingMethodDTO deleteCookingMethodDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
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