using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.App.DTOs;
using Gnocchi.Backend.App.Interfaces;

namespace Gnocchi.Backend.App.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientManager _ingredientManager;

    public IngredientService(IIngredientManager ingredientManager)
    {
        _ingredientManager = ingredientManager;
    }

    public Task<IngredientDTO> AddIngredientAsync(CreateIngredientDTO createIngredientDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteIngredientAsync(DeleteIngredientDTO deleteIngredientDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<IngredientDTO>> GetAllIngredientsAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IngredientDTO> GetIngredientByIdAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IngredientDTO> UpdateIngredientAsync(UpdateIngredientDTO updateIngredientDTO, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}