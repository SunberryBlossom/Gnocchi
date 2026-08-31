namespace Gnocchi.Backend.Models;

public class RecipeStep
{
    #region Properties
    public Guid RecipeId { get; init; }
    #endregion
    #region Navigation properties
    public Guid ResultId { get; set; }
    public Result? Result { get; set; }
    public Guid DishId { get; set; }
    public Dish? Dish { get; set; }
    #endregion
}