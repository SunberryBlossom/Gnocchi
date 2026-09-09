using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteIngredientDTO
{
    [Required]
    public string IngredientId { get; set; } = string.Empty;
}