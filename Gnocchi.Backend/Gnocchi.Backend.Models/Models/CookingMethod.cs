using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.Models;

[Index(nameof(Method))]
public class CookingMethod
{
    #region Properties
    public string? CookingMethodId { get; set; }
    public Method Method { get; set; }
    #endregion
    #region Navigation Properties
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required(ErrorMessage = "A cooking method must belong to a user."), DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    [ForeignKey(nameof(Score))]
    public string? ScoreId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Score? Score { get; set; }
    public ICollection<Result> Results { get; set; } = new List<Result>();
    #endregion
}