using Microsoft.AspNetCore.Identity;

namespace Gnocchi.Backend.Models;

public class User : IdentityUser
{
    #region Navigation Properties
    public ICollection<CookingMethod>? CookingMethods { get; set; }
    public ICollection<Dish>? Dishes { get; set; }
    public ICollection<Ingredient>? Ingredients { get; set; }
    public ICollection<Result>? Results { get; set; }
    public ICollection<Score>? Scores { get; set; }
    public ICollection<Variant>? Variants { get; set; }
    #endregion
}