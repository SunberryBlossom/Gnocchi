namespace Gnocchi.Backend.App.DTOs;

public record CreateResultDTO
{
    public string Comment { get; set; } = string.Empty;
    public string CookingMethodId {get; set;} = string.Empty;
    public string IngredientId { get; set; } = string.Empty;
    public ICollection<string> RecipeStepIds { get; set; } = new List<string>();
}