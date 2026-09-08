using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.App.DTOs;

public record CreateIngredientDTO
{
    public string Name { get; set; } = string.Empty;
    public bool EdibleRaw { get; set; }
    public string ScoreId { get; set; } = string.Empty;
    public ICollection<Result>? Results { get; set; }
}