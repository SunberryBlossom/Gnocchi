using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.DTOs;

public record DishDTO
{
    public string DishId { get; init; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Variant? Variant { get; set; }
    public Score? Score { get; set; }
    public IReadOnlyList<RecipeStep>? RecipeSteps { get; set; }
}