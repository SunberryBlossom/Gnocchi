using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.Models;

public class Variant
{
    #region Properties
    public string? VariantId { get; set; }
    [Required]
    public TypeOfDish? Type { get; set; }
    #endregion
    #region Navigation properties
    public ICollection<Dish>? Dishes { get; set; }
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    #endregion
}