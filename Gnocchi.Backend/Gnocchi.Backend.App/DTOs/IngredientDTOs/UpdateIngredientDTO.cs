namespace Gnocchi.Backend.App.DTOs;

public record UpdateIngredientDTO
{
    public string IngredientId { get; set; } = string.Empty;
    public string Attribute { get; set; } = string.Empty;
    public string NewValue { get; set; } = string.Empty;
}
