using System.ComponentModel.DataAnnotations;

namespace Gnocchi.Backend.App.DTOs;

public record DeleteVariantDTO
{
    [Required(ErrorMessage = "A variant ID is required.")]
    public string VariantId { get; set; } = string.Empty;
}