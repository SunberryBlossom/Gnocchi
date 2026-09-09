using Gnocchi.Backend.Models;
using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.App.DTOs;

public record ScoreDTO
{
    public string ScoreId { get; set; } = string.Empty;
    public Rating Rating { get; set; }
    public ICollection<string> Dishes { get; set; } = new List<string>();
    public ICollection<string> CookingMethods { get; set; } = new List<string>();
    public ICollection<string> Ingredients { get; set; } = new List<string>();
}