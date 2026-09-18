using Gnocchi.Backend.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gnocchi.Backend.Models;

[Index(nameof(Rating))]
public class Score
{
    #region Properties
    public string? ScoreId { get; set; }
    public Rating Rating { get; set; }
    #endregion

    #region Navigation properties
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    public User? User { get; set; }

    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<CookingMethod> CookingMethods { get; set; } = new List<CookingMethod>();
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    #endregion
}