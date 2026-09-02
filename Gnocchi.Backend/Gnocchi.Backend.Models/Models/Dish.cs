namespace Gnocchi.Backend.Models;

public class Dish
{
    #region Properties
    public string? DishId { get; init; }
    [Required]
    public string? Name { get; set; }
    #endregion
    #region Navigation properties
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    [ForeignKey(nameof(Variant))]
    public string? VariantId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.ClientCascade)]
    public Variant? Variant { get; set; }
    [ForeignKey(nameof(Score))]
    public string? ScoreId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Score? Score { get; set; }
    [Required]
    public ICollection<RecipeStep>? RecipeSteps { get; set; }
    #endregion
}