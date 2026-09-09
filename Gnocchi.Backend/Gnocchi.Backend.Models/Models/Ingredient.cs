namespace Gnocchi.Backend.Models;

[Index(nameof(EdibleRaw))]
public class Ingredient
{
    #region Properties
    public string? IngredientId { get; init; }
    [Required(ErrorMessage = "An ingredient name is required.")]
    [StringLength(150, MinimumLength = 1, ErrorMessage = "Ingredient name must be between 1 and 150 characters.")]
    public string? Name { get; set; }
    public bool EdibleRaw { get; set; }
    #endregion
    #region Navigation properties
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required(ErrorMessage = "An ingredient must belong to a user."), DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    [ForeignKey(nameof(Score))]
    public string? ScoreId { get; set; }
    public Score? Score { get; set; }
    public ICollection<Result> Results { get; set; } = new List<Result>();
    #endregion
}