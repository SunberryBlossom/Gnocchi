using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.App.DTOs;

public record VariantDTO
{
    public string VariantId { get; set; } = string.Empty;
    public TypeOfDish? Type { get; set; }
    public IReadOnlyList<string> Dishes { get; set; } = new List<string>();
}