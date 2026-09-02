namespace Gnocchi.Backend.Models;

public class Result
{
    // TODO: The delete behaviours are NOT optimised here... Both Cannot be cascading due to race issues.
    #region Properties
    public string? ResultId { get; init; }
    [Required]
    public string? Comment { get; set; }
    #endregion
    #region navigation properties
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    [ForeignKey(nameof(Ingredient))]
    public string? IngredientId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Ingredient? Ingredient { get; set; }
    [ForeignKey(nameof(CookingMethod))]
    public string? CookingMethodId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public CookingMethod? CookingMethod { get; set; }
    public ICollection<RecipeStep>? RecipeSteps { get; set; }
    #endregion
}