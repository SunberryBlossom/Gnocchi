using Gnocchi.Backend.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateScoreDTO
{
    [EnumDataType(typeof(Rating), ErrorMessage = "Rating must be a valid rating from one to five stars.")]
    public Rating Rating {get; set;}
    public ICollection<string> DishIds { get; set; } = new List<string>();
    public ICollection<string> CookingMethodIds { get; set; } = new List<string>();
    public ICollection<string> IngredientIds { get; set; } = new List<string>();
}