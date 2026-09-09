using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteDishDTO
{
    [Required(ErrorMessage = "A dish ID is required.")]
    public string DishId { get; set; } = string.Empty;
}