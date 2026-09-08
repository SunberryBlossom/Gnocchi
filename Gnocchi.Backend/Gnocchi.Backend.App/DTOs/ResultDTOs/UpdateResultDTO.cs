namespace Gnocchi.Backend.App.DTOs;

public record UpdateResultDTO
{
    public string ResultId { get; set; } = string.Empty;
    public string NewValue { get; set; } = string.Empty;
}