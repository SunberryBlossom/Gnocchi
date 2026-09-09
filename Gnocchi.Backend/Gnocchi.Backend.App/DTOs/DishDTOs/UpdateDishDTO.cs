using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record UpdateDishDTO
{
    [Required]
    public string DishId { get; set; } = string.Empty;
    [Required, RegularExpression("name|variant|score", ErrorMessage = "Attribute must be name, variant, or score.")]
    public string Attribute { get; set; } = string.Empty;
    [Required, StringLength(150, MinimumLength = 1)]
    public string NewValue { get; set; } = string.Empty;
}