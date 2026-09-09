namespace Gnocchi.Backend.Models;

public class Result
{
    // TODO: The delete behaviours are NOT optimised here... Both Cannot be cascading due to race issues.
    #region Properties
    public string? ResultId { get; init; }
    [Required(ErrorMessage = "A result comment is required.")]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = "Result comment must be between 1 and 1000 characters.")]
    public string? Comment { get; set; }
    #endregion
    #region navigation properties
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required(ErrorMessage = "A result must belong to a user."), DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    [ForeignKey(nameof(Ingredient))]
    public string? IngredientId { get; set; }
    [Required(ErrorMessage = "A result must have an ingredient."), DeleteBehavior(DeleteBehavior.NoAction)]
    public Ingredient? Ingredient { get; set; }
    [ForeignKey(nameof(CookingMethod))]
    public string? CookingMethodId { get; set; }
    [Required(ErrorMessage = "A result must have a cooking method."), DeleteBehavior(DeleteBehavior.NoAction)]
    public CookingMethod? CookingMethod { get; set; }
    public ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
    #endregion
}