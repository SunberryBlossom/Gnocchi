using Gnocchi.Backend.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace Gnocchi.Backend.Models;

public class CookingMethod
{
    #region Properties
    public Guid CookingMethodId { get; set; }
    [Required]
    public Method Method { get; set; }
    #endregion
    #region Navigation Properties
    [ForeignKey(nameof(Score))]
    public Guid? ScoreId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Score? Score { get; set; }
    public ICollection<Result>? Results { get; set; }
    #endregion
}