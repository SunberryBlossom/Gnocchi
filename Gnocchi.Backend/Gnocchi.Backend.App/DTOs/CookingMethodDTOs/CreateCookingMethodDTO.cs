using Gnocchi.Backend.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateCookingMethodDTO
{
    [EnumDataType(typeof(Method), ErrorMessage = "Method must be a valid cooking method.")]
    public Method Method { get; set; }
    [Required(ErrorMessage = "A score ID is required.")]
    public string ScoreId { get; set; } = string.Empty;
    public ICollection<string> ResultIds { get; set; } = new List<string>();
}