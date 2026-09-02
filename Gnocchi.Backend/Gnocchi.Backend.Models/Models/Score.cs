using Gnocchi.Backend.Shared.Enums;
namespace Gnocchi.Backend.Models;

public class Score
{
    #region Properties
    public string? ScoreId { get; set; }
    [Required]
    public Rating Rating { get; set; }
    #endregion
    #region Navigation properties
    [ForeignKey(nameof(User))]
     public string? UserId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    public ICollection<Dish>? Dishes { get; set; }
    public ICollection<CookingMethod>? CookingMethods { get; set; }
    public ICollection<Ingredient>? Ingredients { get; set; }
    #endregion
}