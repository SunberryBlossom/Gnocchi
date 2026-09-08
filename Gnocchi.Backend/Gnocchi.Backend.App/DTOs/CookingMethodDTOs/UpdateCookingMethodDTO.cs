namespace Gnocchi.Backend.App.DTOs;

public record UpdateCookingMethodDTO
{
    public string CookingMethodId { get; set; } = string.Empty;
    public string ScoreId { get; set; } = string.Empty;
}