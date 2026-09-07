using Gnocchi.Backend.Models;
using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.App.DTOs;

public record ScoreDTO
{
    public string ScoreId { get; set; } = string.Empty;
    public Rating Rating { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<CookingMethod> CookingMethods { get; set; } = new List<CookingMethod>();
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}