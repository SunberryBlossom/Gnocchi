using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.DTOs;

public record CreateDishDTO
{
    public string Name { get; set; } = string.Empty;
    public Variant? Variant { get; set; }
    public Score? Score { get; set; }
    public ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
}