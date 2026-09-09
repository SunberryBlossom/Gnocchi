using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record CreateIngredientDTO
{
    [Required(ErrorMessage = "An ingredient name is required."), StringLength(150, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 150 characters.")]
    public string Name { get; set; } = string.Empty;
    public bool EdibleRaw { get; set; }
    [Required(ErrorMessage = "A score ID is required.")]
    public string ScoreId { get; set; } = string.Empty;
    public ICollection<string> ResultIds { get; set; } = new List<string>();
}