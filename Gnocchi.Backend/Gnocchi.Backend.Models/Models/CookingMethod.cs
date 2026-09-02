using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.Models;

public class CookingMethod
{
    #region Properties
    public string? CookingMethodId { get; set; }
    [Required]
    public Method Method { get; set; }
    #endregion
    #region Navigation Properties
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    [ForeignKey(nameof(Score))]
    public string? ScoreId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Score? Score { get; set; }
    public ICollection<Result>? Results { get; set; }
    #endregion
}