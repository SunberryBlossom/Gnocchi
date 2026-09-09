using Gnocchi.Backend.Shared.Enums;
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
    [Required(ErrorMessage = "A score must belong to a user."), DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<CookingMethod> CookingMethods { get; set; } = new List<CookingMethod>();
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    #endregion
}