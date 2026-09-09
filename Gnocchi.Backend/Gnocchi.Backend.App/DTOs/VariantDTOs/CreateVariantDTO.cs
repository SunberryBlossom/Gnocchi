using Gnocchi.Backend.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateVariantDTO
{
    [Required, StringLength(150, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
    [Required, EnumDataType(typeof(TypeOfDish))]
    public TypeOfDish? Type { get; set; }
    public ICollection<string> DishIds { get; set; } = new List<string>();
}