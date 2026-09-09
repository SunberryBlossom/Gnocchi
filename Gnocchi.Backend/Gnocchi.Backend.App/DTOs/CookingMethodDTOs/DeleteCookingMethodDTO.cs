using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteCookingMethodDTO
{
    [Required(ErrorMessage = "A cooking method ID is required.")]
    public string CookingMethodId { get; set; } = string.Empty;
}