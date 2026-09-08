namespace Gnocchi.Backend.App.DTOs;

public record DeleteCookingMethodDTO
{
    public string CookingMethodId { get; set; } = string.Empty;
}