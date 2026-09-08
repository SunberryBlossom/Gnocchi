namespace Gnocchi.Backend.App.DTOs;

public record DeleteResultDTO
{
    public string ResultId { get; set; } = string.Empty;
}