using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteResultDTO
{
    [Required]
    public string ResultId { get; set; } = string.Empty;
}