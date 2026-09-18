using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.Interfaces;

public interface IRecipeStepManager
{
    Task AddAsync(RecipeStep recipeStep, CancellationToken ct = default);
    Task<IReadOnlyList<RecipeStep>?> GetAllAsync(CancellationToken ct = default);
    Task<RecipeStep?> GetByIdAsync(string id, CancellationToken ct = default);
    Task<RecipeStep?> GetCompleteByIdAsync(string id, CancellationToken ct = default);
    Task<RecipeStep?> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default);
    Task RemoveAsync(RecipeStep recipeStep, CancellationToken ct = default);
}