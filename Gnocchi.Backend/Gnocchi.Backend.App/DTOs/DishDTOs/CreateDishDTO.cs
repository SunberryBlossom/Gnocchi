using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateDishDTO
{
    [Required(ErrorMessage = "A dish name is required."), StringLength(150, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 150 characters.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "A variant ID is required.")]
    public string VariantId {get; set;} = string.Empty;
    [Required(ErrorMessage = "A score ID is required.")]
    public string ScoreId { get; set; } = string.Empty;
    public ICollection<string> RecipeStepIds { get; set; } = new List<string>();
}