using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record UpdateResultDTO
{
    [Required]
    public string ResultId { get; set; } = string.Empty;
    [Required, StringLength(1000, MinimumLength = 1)]
    public string NewValue { get; set; } = string.Empty;
}