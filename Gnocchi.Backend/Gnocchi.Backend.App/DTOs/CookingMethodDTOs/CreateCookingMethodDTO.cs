using Gnocchi.Backend.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateCookingMethodDTO
{
    [EnumDataType(typeof(Method))]
    public Method Method { get; set; }
    [Required]
    public string ScoreId { get; set; } = string.Empty;
    public ICollection<string> ResultIds { get; set; } = new List<string>();
}