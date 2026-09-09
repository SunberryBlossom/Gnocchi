using Microsoft.AspNetCore.Identity;

namespace Gnocchi.Backend.Models;

public class User : IdentityUser
{
    #region Navigation Properties
    public ICollection<CookingMethod> CookingMethods { get; set; } = new List<CookingMethod>();
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public ICollection<Result> Results { get; set; } = new List<Result>();
    public ICollection<Score> Scores { get; set; } = new List<Score>();
    public ICollection<Variant> Variants { get; set; } = new List<Variant>();
    #endregion
}