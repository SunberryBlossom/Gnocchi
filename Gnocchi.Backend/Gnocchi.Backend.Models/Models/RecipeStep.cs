namespace Gnocchi.Backend.Models;

public class RecipeStep
{
    #region Properties
    public string? RecipeStepId { get; init; }
    #endregion
    #region Navigation properties
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    [ForeignKey(nameof(Result))]
    public string? ResultId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Result? Result { get; set; }
    [ForeignKey(nameof(Dish))]
    public string? DishId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Dish? Dish { get; set; }
    #endregion
}