using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateResultDTO
{
    [Required(ErrorMessage = "A comment is required."), StringLength(1000, MinimumLength = 1, ErrorMessage = "Comment must be between 1 and 1000 characters.")]
    public string Comment { get; set; } = string.Empty;
    [Required(ErrorMessage = "A cooking method ID is required.")]
    public string CookingMethodId {get; set;} = string.Empty;
    [Required(ErrorMessage = "An ingredient ID is required.")]
    public string IngredientId { get; set; } = string.Empty;
    public ICollection<string> RecipeStepIds { get; set; } = new List<string>();
}