using Gnocchi.Backend.App.DTOs;

namespace Gnocchi.Backend.App.Interfaces;

public interface IRecipeStepService
{
    Task<RecipeStepDTO> AddRecipeStepAsync(CreateRecipeStepDTO createRecipeStepDTO, CancellationToken ct = default);
    Task DeleteRecipeStepAsync(DeleteRecipeStepDTO deleteRecipeStepDTO, CancellationToken ct = default);
    Task<IReadOnlyList<RecipeStepDTO>> GetAllRecipeStepsAsync(CancellationToken ct = default);
    Task<RecipeStepDTO> GetRecipeStepByIdAsync(string id, CancellationToken ct = default);
}