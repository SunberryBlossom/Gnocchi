using Gnocchi.Backend.Models;
using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.App.DTOs;

public record CookingMethodDTO
{
    public string CookingMethodId { get; set; } = string.Empty;
    public Method Method { get; set; }
    public string ScoreId { get; set; } = string.Empty;
    public ICollection<Result> Results { get; set; } = new List<Result>();
}