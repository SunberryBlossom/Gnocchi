namespace Gnocchi.Backend.App.DTOs;

public record DeleteVariantDTO
{
    public string VariantId { get; set; } = string.Empty;
}