using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.DTOs;

public record DishDTO
{
    public string DishId { get; init; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string VariantId { get; set; } = string.Empty;
    public string ScoreId { get; set; } = string.Empty;
    public IReadOnlyList<RecipeStep>? RecipeSteps { get; set; }
}