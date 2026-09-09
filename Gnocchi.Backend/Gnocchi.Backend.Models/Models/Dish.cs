namespace Gnocchi.Backend.Models;

[Index(nameof(Name), IsUnique = true)]
public class Dish
{
    #region Properties
    public string? DishId { get; init; }
    [Required(ErrorMessage = "A dish name is required.")]
    [StringLength(150, MinimumLength = 1, ErrorMessage = "Dish name must be between 1 and 150 characters.")]
    public string? Name { get; set; }
    #endregion
    #region Navigation properties
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required(ErrorMessage = "A dish must belong to a user."), DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    [ForeignKey(nameof(Variant))]
    public string? VariantId { get; set; }
    [Required(ErrorMessage = "A dish must have a variant."), DeleteBehavior(DeleteBehavior.ClientCascade)]
    public Variant? Variant { get; set; }
    [ForeignKey(nameof(Score))]
    public string? ScoreId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Score? Score { get; set; }
    public ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
    #endregion
}