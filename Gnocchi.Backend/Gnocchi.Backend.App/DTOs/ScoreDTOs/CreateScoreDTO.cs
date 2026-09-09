using Gnocchi.Backend.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateScoreDTO
{
    [EnumDataType(typeof(Rating))]
    public Rating Rating {get; set;}
    public ICollection<string> DishIds { get; set; } = new List<string>();
    public ICollection<string> CookingMethodIds { get; set; } = new List<string>();
    public ICollection<string> IngredientIds { get; set; } = new List<string>();
}