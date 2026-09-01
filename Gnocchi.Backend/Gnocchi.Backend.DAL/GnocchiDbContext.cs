using Gnocchi.Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // To inherit from superclass IdentityDbContext<T>
using Microsoft.EntityFrameworkCore; // To use DbSet

namespace Gnocchi.Backend.DAL;

public class GnocchiDbContext : IdentityDbContext<User>
{
    #region Constructors
    public GnocchiDbContext(DbContextOptions<GnocchiDbContext> options) : base(options) { }
    #endregion

    #region DBSets
    public DbSet<CookingMethod> CookingMethods { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeStep> RecipeSteps { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<Variant> Variants { get; set; }
    #endregion
}