using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.Models;

public class CookingMethod
{
    #region Properties
    public Guid CookingMethodId { get; set; }
    public Method Method { get; set; }
    #endregion
    #region Navigation Properties
    public Guid ScoreId { get; set; }
    public Score? Score { get; set; }
    public ICollection<Result> Results { get; set; } = new List<Result>();
    #endregion
}