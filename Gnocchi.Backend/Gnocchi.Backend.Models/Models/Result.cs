
using Microsoft.EntityFrameworkCore;

namespace Gnocchi.Backend.Models;

public class Result
{
    // TODO: The delete behaviours are NOT optimised here... Both Cannot be cascading due to race issues.
    #region Properties
    public Guid Id { get; init; }
    [Required]
    public string? Comment { get; set; }
    #endregion
    #region navigation properties
    [ForeignKey(nameof(Ingredient))]
    public Guid IngredientId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Ingredient? Ingredient { get; set; }
    [ForeignKey(nameof(CookingMethod))]
    public Guid CookingMethodId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public CookingMethod? CookingMethod { get; set; }
    public ICollection<RecipeStep>? RecipeSteps { get; set; }
    #endregion
}