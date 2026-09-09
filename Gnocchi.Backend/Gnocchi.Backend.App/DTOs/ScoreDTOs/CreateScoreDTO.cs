using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.App.DTOs;

public record CreateScoreDTO
{
    public Rating Rating {get; set;}
    public ICollection<string> DishIds { get; set; } = new List<string>();
    public ICollection<string> CookingMethodIds { get; set; } = new List<string>();
    public ICollection<string> IngredientIds { get; set; } = new List<string>();
}