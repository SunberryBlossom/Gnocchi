using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteCookingMethodDTO
{
    [Required]
    public string CookingMethodId { get; set; } = string.Empty;
}