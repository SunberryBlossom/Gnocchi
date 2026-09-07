namespace Gnocchi.Backend.App.DTOs;

public record DeleteDishDTO
{
    public string DishId { get; set; } = string.Empty;
}