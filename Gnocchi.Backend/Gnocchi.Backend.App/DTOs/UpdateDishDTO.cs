namespace Gnocchi.Backend.App.DTOs;

public record UpdateDishDTO
{
    public string DishId { get; set; } = string.Empty;
    public string Attribute { get; set; } = string.Empty;
    public string NewValue { get; set; } = string.Empty;
}