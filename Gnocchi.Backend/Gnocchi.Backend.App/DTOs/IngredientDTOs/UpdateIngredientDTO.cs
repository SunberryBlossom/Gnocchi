using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record UpdateIngredientDTO
{
    [Required]
    public string IngredientId { get; set; } = string.Empty;
    [Required]
    public string Attribute { get; set; } = string.Empty;
    [Required, StringLength(150, MinimumLength = 1)]
    public string NewValue { get; set; } = string.Empty;
}
