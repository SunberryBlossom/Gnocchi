using Gnocchi.Backend.Models;
using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.App.DTOs;

public record CreateVariantDTO
{
    public string Name { get; set; } = string.Empty;
    public TypeOfDish? Type { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}