namespace Gnocchi.Backend.Models;

public class Ingredient
{
    #region Properties
    public Guid IngredientId { get; init; }
    public string? Name { get; set; }
    public bool EdibleRaw { get; set; }
    #endregion
    #region Navigation properties
    public Guid ScoreId { get; set; }
    public Score? Score { get; set; }
    public ICollection<Result>? Results { get; set; }
    #endregion
}