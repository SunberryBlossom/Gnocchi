using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record UpdateCookingMethodDTO
{
    [Required]
    public string CookingMethodId { get; set; } = string.Empty;
    [Required]
    public string ScoreId { get; set; } = string.Empty;
}