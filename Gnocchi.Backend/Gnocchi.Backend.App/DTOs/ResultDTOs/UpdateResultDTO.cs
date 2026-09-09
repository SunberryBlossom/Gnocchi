using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record UpdateResultDTO
{
    [Required(ErrorMessage = "A result ID is required.")]
    public string ResultId { get; set; } = string.Empty;
    [Required(ErrorMessage = "A new value is required."), StringLength(1000, MinimumLength = 1, ErrorMessage = "The new value must be between 1 and 1000 characters.")]
    public string NewValue { get; set; } = string.Empty;
}