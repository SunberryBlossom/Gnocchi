using Microsoft.EntityFrameworkCore;

namespace Gnocchi.Backend.Models;

public class Dish
{
    #region Properties
    public Guid DishId { get; init; }
    [Required]
    public string? Name { get; set; }
    #endregion
    #region Navigation properties
    [ForeignKey(nameof(Variant))]
    public Guid VariantId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Variant? Variant { get; set; }
    [ForeignKey(nameof(Score))]
    public Guid? ScoreId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Score? Score { get; set; }
    [Required]
    public ICollection<RecipeStep>? RecipeSteps { get; set; }
    #endregion
}