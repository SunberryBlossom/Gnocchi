using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteIngredientDTO
{
    [Required(ErrorMessage = "An ingredient ID is required.")]
    public string IngredientId { get; set; } = string.Empty;
}