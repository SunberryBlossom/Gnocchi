namespace Gnocchi.Backend.Models;

public class Dish
{
    #region Properties
    public Guid DishId { get; init; }
    public string? Name { get; set; }
    #endregion
    #region Navigation properties
    public Guid VariantId { get; set; }
    public Variant? Variant { get; set; }
    public Guid ScoreId { get; set; }
    public Score? Score { get; set; }
    public ICollection<RecipeStep>? RecipeSteps { get; set; }
    #endregion
}