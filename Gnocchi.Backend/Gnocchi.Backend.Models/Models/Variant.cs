using Gnocchi.Backend.Shared.Enums;

namespace Gnocchi.Backend.Models;

[Index(nameof(Type))]
public class Variant
{
    #region Properties
    public string? VariantId { get; set; }
    [Required(ErrorMessage = "A dish type is required.")]
    public TypeOfDish? Type { get; set; }
    #endregion
    #region Navigation properties
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    [Required(ErrorMessage = "A variant must belong to a user."), DeleteBehavior(DeleteBehavior.Cascade)]
    public User? User { get; set; }
    #endregion
}