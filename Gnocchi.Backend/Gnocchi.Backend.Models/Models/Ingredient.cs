namespace Gnocchi.Backend.Models;

[Index(nameof(EdibleRaw))]
public class Ingredient
{
    #region Properties
    public string? IngredientId { get; init; }
    [Required]
    [MaxLength(28)]
    public string? Name { get; set; }
    [Required]
    public bool EdibleRaw { get; set; }
    #endregion
    #region Navigation properties
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    [ForeignKey(nameof(Score))]
    public string? ScoreId { get; set; }
    public Score? Score { get; set; }
    public ICollection<Result>? Results { get; set; }
    #endregion
}