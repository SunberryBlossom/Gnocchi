using Gnocchi.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // To inherit from superclass IdentityDbContext<T>
using Microsoft.EntityFrameworkCore; // To use DbSet

namespace Gnocchi.Backend.DAL;

public class GnocchiDbContext : IdentityDbContext<User>, IUnitOfWork
{
    private readonly ICurrentUserAccessor _currentUser;
    private const string AdminRoleId = "8f4c3b1a-2d5e-4f6a-9b7c-1e2f3a4b5c6d";

    #region Constructors
    public GnocchiDbContext(
        DbContextOptions<GnocchiDbContext> options,
        ICurrentUserAccessor currentUser) : base(options)
    {
        _currentUser = currentUser;
    }
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
    #region Design time configuration
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<CookingMethod>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<Dish>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<Ingredient>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<RecipeStep>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<Result>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<Score>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<Variant>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = AdminRoleId,
                Name = "admin",
                NormalizedName = "ADMIN",
            }
        );


    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var applicationEntries = ChangeTracker.Entries()
            .Where(entry => entry.Entity is CookingMethod
                or Dish
                or Ingredient
                or RecipeStep
                or Result
                or Score
                or Variant)
            .ToList();

        if (applicationEntries.Any() && !_currentUser.IsAdmin && _currentUser.UserId is null)
        {
            throw new InvalidOperationException("An authenticated user is required to modify application data.");
        }

        foreach (var entry in applicationEntries.Where(entry => entry.State == EntityState.Added))
        {
            var userIdProperty = entry.Properties.FirstOrDefault(property => property.Metadata.Name == nameof(Dish.UserId));
            if (userIdProperty is not null)
            {
                userIdProperty.CurrentValue = _currentUser.UserId;
            }
        }

        if (!_currentUser.IsAdmin)
        {
            foreach (var entry in applicationEntries.Where(entry => entry.State is EntityState.Modified or EntityState.Deleted))
            {
                var ownerId = entry.Property(nameof(Dish.UserId)).CurrentValue as string;
                if (ownerId != _currentUser.UserId)
                {
                    throw new UnauthorizedAccessException("Users may only modify their own entities.");
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
    #endregion
}