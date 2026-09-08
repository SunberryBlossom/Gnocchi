namespace Gnocchi.Backend.App.DTOs;

public record DeleteIngredientDTO
{
    public string IngredientId { get; set; } = string.Empty;
}