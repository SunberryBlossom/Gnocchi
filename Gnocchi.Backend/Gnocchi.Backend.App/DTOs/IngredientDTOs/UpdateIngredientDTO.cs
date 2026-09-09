using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record UpdateIngredientDTO
{
    [Required(ErrorMessage = "An ingredient ID is required.")]
    public string IngredientId { get; set; } = string.Empty;
    [Required(ErrorMessage = "An attribute is required."), RegularExpression("name|variant|score", ErrorMessage = "Attribute must be name, variant, or score.")]
    public string Attribute { get; set; } = string.Empty;
    [Required(ErrorMessage = "A new value is required."), StringLength(150, MinimumLength = 1, ErrorMessage = "The new value must be between 1 and 150 characters.")]
    public string NewValue { get; set; } = string.Empty;
}
