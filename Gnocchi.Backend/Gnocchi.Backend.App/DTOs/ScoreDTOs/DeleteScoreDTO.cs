using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteScoreDTO
{
    [Required]
    public string Id {get; set;} = string.Empty;
}