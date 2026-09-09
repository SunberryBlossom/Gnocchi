using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteVariantDTO
{
    [Required]
    public string VariantId { get; set; } = string.Empty;
}