
namespace Gnocchi.Backend.Models;

public class Result
{
    #region Properties
    public Guid Id { get; init; }
    public string Comment { get; set; } = string.Empty;
    #endregion
    #region navigation properties
    public Guid IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }
    public Guid CookingMethodId { get; set; }
    public CookingMethod? CookingMethod { get; set; }
    public ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
    #endregion
}