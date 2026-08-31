using Gnocchi.Backend.Shared.Enums;
namespace Gnocchi.Backend.Models;

public class Score
{
    #region Properties
    public Guid ScoreId { get; set; }
    public Rating Rating { get; set; }
    #endregion
    #region Navigation properties
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<CookingMethod> CookingMethods { get; set; } = new List<CookingMethod>();
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    #endregion
}