using Microsoft.EntityFrameworkCore;

namespace Gnocchi.Backend.Models;

public class RecipeStep
{
    #region Properties
    public Guid RecipeStepId { get; init; }
    #endregion
    #region Navigation properties
    [ForeignKey(nameof(Result))]
    public Guid ResultId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Result? Result { get; set; }
    [ForeignKey(nameof(Dish))]
    public Guid DishId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Dish? Dish { get; set; }
    #endregion
}