namespace Gnocchi.Backend.App.DTOs;

public record RecipeStepDTO
{
    public string RecipeStepId { get; set; } = string.Empty;
    public string ResultId { get; set; } = string.Empty;
    public string DishId { get; set; } = string.Empty;
}