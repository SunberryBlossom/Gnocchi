using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteResultDTO
{
    [Required(ErrorMessage = "A result ID is required.")]
    public string ResultId { get; set; } = string.Empty;
}