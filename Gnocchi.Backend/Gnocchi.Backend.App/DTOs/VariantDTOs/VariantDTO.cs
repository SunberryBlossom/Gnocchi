using Gnocchi.Backend.Models;
using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.App.DTOs;

public record UpdateVariantDTO
{
    public string VariantId { get; set; } = string.Empty;
    public TypeOfDish? Type { get; set; }
    public IReadOnlyList<Dish> Dishes { get; set; } = new List<Dish>();
}