using Gnocchi.Backend.Models;
using Gnocchi.Backend.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Gnocchi.Backend.DAL;

public class GnocchiDbContext : IdentityDbContext<User>, IUnitOfWork
{
    private readonly ICurrentUserAccessor _currentUser;

    #region Constructors
    public GnocchiDbContext(
        DbContextOptions<GnocchiDbContext> options,
        ICurrentUserAccessor currentUser) : base(options)
    {
        _currentUser = currentUser;
    }
    #endregion

    #region DbSets
    public DbSet<CookingMethod> CookingMethods { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeStep> RecipeSteps { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<Variant> Variants { get; set; }
    #endregion

    #region Design time configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        // Tystar EF Core 9-varningen som spärrar databasuppdateringen
        optionsBuilder.ConfigureWarnings(warnings => 
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<CookingMethod>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<Dish>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<Ingredient>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<RecipeStep>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<Result>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);
        builder.Entity<Variant>().HasQueryFilter(entity => _currentUser.IsAdmin || entity.UserId == _currentUser.UserId);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "f3796d13-4318-47d0-9d41-3b5674a2b91d",
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "a1b2c3d4-0000-0000-0000-123456789abc" // Fast hårdkodat värde
            }
        );

        builder.Entity<Score>().HasData(
            new Score { ScoreId = "10000000-0000-0000-0000-000000000001", Rating = Rating.One, UserId = null },
            new Score { ScoreId = "10000000-0000-0000-0000-000000000002", Rating = Rating.Two, UserId = null },
            new Score { ScoreId = "10000000-0000-0000-0000-000000000003", Rating = Rating.Three, UserId = null },
            new Score { ScoreId = "10000000-0000-0000-0000-000000000004", Rating = Rating.Four, UserId = null },
            new Score { ScoreId = "10000000-0000-0000-0000-000000000005", Rating = Rating.Five, UserId = null }
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