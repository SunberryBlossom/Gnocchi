using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateDishDTO
{
    [Required, StringLength(150, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string VariantId {get; set;} = string.Empty;
    [Required]
    public string ScoreId { get; set; } = string.Empty;
    public ICollection<string> RecipeStepIds { get; set; } = new List<string>();
}