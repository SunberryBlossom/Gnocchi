using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteScoreDTO
{
    [Required(ErrorMessage = "A score ID is required.")]
    public string Id {get; set;} = string.Empty;
}