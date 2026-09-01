using Gnocchi.Backend.Shared.Enums;
namespace Gnocchi.Backend.Models;

public class Score
{
    #region Properties
    public Guid ScoreId { get; set; }
    [Required]
    public Rating Rating { get; set; }
    #endregion
    #region Navigation properties
    public ICollection<Dish>? Dishes { get; set; }
    public ICollection<CookingMethod>? CookingMethods { get; set; }
    public ICollection<Ingredient>? Ingredients { get; set; }
    #endregion
}