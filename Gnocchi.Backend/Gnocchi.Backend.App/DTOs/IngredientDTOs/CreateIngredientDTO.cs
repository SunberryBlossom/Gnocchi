using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateIngredientDTO
{
    [Required, StringLength(150, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
    public bool EdibleRaw { get; set; }
    [Required]
    public string ScoreId { get; set; } = string.Empty;
    public ICollection<string> ResultIds { get; set; } = new List<string>();
}