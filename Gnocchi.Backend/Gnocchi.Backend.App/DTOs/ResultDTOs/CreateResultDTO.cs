using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateResultDTO
{
    [Required, StringLength(1000, MinimumLength = 1)]
    public string Comment { get; set; } = string.Empty;
    [Required]
    public string CookingMethodId {get; set;} = string.Empty;
    [Required]
    public string IngredientId { get; set; } = string.Empty;
    public ICollection<string> RecipeStepIds { get; set; } = new List<string>();
}