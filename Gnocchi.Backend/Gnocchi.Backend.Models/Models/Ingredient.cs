namespace Gnocchi.Backend.Models;

public class Ingredient
{
    #region Properties
    public Guid IngredientId { get; init; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public bool EdibleRaw { get; set; }
    #endregion
    #region Navigation properties
    [ForeignKey(nameof(Score))]
    public Guid? ScoreId { get; set; }
    public Score? Score { get; set; }
    public ICollection<Result>? Results { get; set; }
    #endregion
}