using Gnocchi.Backend.Bll.Interfaces;
using Gnocchi.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Gnocchi.Backend.DAL.Repositories;

public class DishRepository : IDishRepository
{
    #region Fields
    private readonly GnocchiDbContext _dbContext;
    #endregion
    #region Constructors
    public DishRepository(GnocchiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion
    #region Create methods
    public void Add(Dish dish)
    {
        _dbContext.Dishes.Add(dish);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<Dish>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbContext.Dishes.AsNoTracking().ToListAsync(ct);
    }
    public async Task<Dish?> GetAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Dishes.FindAsync(id, ct);
    }
    public async Task<Dish?> GetFullAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Dishes
        .Where(dish => dish.DishId == id)
        .Include(dish => dish.Variant)
        .Include(dish => dish.Score)
        .Include(dish => dish.RecipeSteps)
        .AsNoTracking()
        .AsSplitQuery()
        .FirstOrDefaultAsync(ct);
    }
    public async Task<Dish?> GetwithRecipeStepsAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Dishes
        .Where(dish => dish.DishId == id)
        .Include(dish => dish.RecipeSteps)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    public async Task<Dish?> GetWithScoreAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Dishes
        .Where(dish => dish.DishId == id)
        .Include(dish => dish.Score)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    public async Task<Dish?> GetWithVariantAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Dishes
       .Where(dish => dish.DishId == id)
       .Include(dish => dish.Variant)
       .AsNoTracking()
       .FirstOrDefaultAsync(ct);
    }
    #endregion
    #region Update methods
    public async Task<Dish?> UpdateNameAsync(string id, string newName, CancellationToken ct = default)
    {
        var dish = await _dbContext.Dishes.FindAsync(id, ct);
        if (dish is null)
        {
            return null;
        }
        dish.Name = newName;
        return dish;
    }
    public async Task<Dish?> UpdateScoreAsync(string dishId, string newScoreId, CancellationToken ct = default)
    {
        var dish = await _dbContext.Dishes.FindAsync(dishId, ct);
        if (dish is null)
        {
            return null;
        }
        dish.ScoreId = newScoreId;
        return dish;
    }
    public async Task<Dish?> UpdateVariantAsync(string dishId, string newVariantId, CancellationToken ct = default)
    {
        var dish = await _dbContext.Dishes.FindAsync(dishId, ct);
        if (dish is null)
        {
            return null;
        }
        dish.VariantId = newVariantId;
        return dish;
    }
    #endregion
    #region Delete methods
    public void Remove(Dish dish)
    {
        _dbContext.Dishes.Remove(dish);
    }
    #endregion
}