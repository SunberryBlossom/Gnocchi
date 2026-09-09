using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteDishDTO
{
    [Required]
    public string DishId { get; set; } = string.Empty;
}