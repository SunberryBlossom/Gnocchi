using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.DTOs;

public record CreateDishDTO
{
    public string Name { get; set; } = string.Empty;
    public string VariantId {get; set;} = string.Empty;
    public string ScoreId { get; set; } = string.Empty;
    public ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
}