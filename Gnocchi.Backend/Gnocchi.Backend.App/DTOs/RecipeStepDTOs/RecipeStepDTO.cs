namespace Gnocchi.Backend.App.DTOs;

public class CreateRecipeStepDTO
{
    public string DishId { get; set; } = string.Empty;
    public string ResultId { get; set; } = string.Empty;
}

public class RecipeStepDTO
{
    public string RecipeStepId { get; set; } = string.Empty;
    public string DishId { get; set; } = string.Empty;
    public string ResultId { get; set; } = string.Empty;
}

public class DeleteRecipeStepDTO
{
    public string RecipeStepId { get; set; } = string.Empty;
}