using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record UpdateCookingMethodDTO
{
    [Required(ErrorMessage = "A cooking method ID is required.")]
    public string CookingMethodId { get; set; } = string.Empty;
    [Required(ErrorMessage = "A score ID is required.")]
    public string ScoreId { get; set; } = string.Empty;
}