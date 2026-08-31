namespace Gnocchi.Backend.Models;

public class Variant
{
    #region Properties
    public Guid VariantId { get; set; }
    public Type? Type { get; set; }
    #endregion
    #region Navigation properties
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    #endregion
}