using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.DTOs;

public record ResultDTO
{
    public string ResultId { get; init; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string IngredientId { get; set; } = string.Empty;
    public string CookingMethodId { get; set; } = string.Empty;
    public IReadOnlyList<string>? RecipeStepIds { get; set; } = new List<string>();
}