using Gnocchi.Backend.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateVariantDTO
{
    [Required(ErrorMessage = "A variant name is required."), StringLength(150, MinimumLength = 1, ErrorMessage = "The name must be between 1 and 150 characters.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "A dish type is required."), EnumDataType(typeof(TypeOfDish), ErrorMessage = "Type must be a valid dish type.")]
    public TypeOfDish? Type { get; set; }
    public ICollection<string> DishIds { get; set; } = new List<string>();
}