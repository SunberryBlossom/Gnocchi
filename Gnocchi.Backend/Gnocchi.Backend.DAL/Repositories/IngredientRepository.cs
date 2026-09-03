using Gnocchi.Backend.Bll.Interfaces;
using Gnocchi.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Gnocchi.Backend.DAL.Repositories;

public class IngredientRepository : IIngredientRepository
{

    #region Fields
    private readonly GnocchiDbContext _dbContext;
    #endregion
    #region Constructors
    public IngredientRepository(GnocchiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion
    #region Create methods
    public void Add(Ingredient ingredient)
    {
        _dbContext.Ingredients.Add(ingredient);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<Ingredient>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbContext.Ingredients.ToListAsync(ct);
    }
    public async Task<Ingredient?> GetAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Ingredients.FindAsync(id, ct);
    }
    public async Task<Ingredient?> GetFullAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Ingredients
        .Where(ingredient => ingredient.IngredientId == id)
        .Include(ingredient => ingredient.Results)
        .Include(ingredient => ingredient.Score)
        .AsNoTracking()
        .AsSplitQuery()
        .FirstOrDefaultAsync(ct);
    }
    public async Task<Ingredient?> GetWithResultsAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Ingredients
        .Where(ingredient => ingredient.IngredientId == id)
        .Include(ingredient => ingredient.Results)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    public async Task<Ingredient?> GetWithScoreAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Ingredients
        .Where(ingredient => ingredient.IngredientId == id)
        .Include(ingredient => ingredient.Score)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    #endregion
    #region  Update methods
    public async Task<Ingredient?> UpdateNameAsync(string id, string newName, CancellationToken ct = default)
    {
        var ingredient = await _dbContext.Ingredients.FindAsync(id, ct);
        if (ingredient is null)
        {
            return null;
        }
        ingredient.Name = newName;
        return ingredient;
    }
    public async Task<Ingredient?> UpdateRawEdibleAsync(string id, bool newEdibility, CancellationToken ct = default)
    {
        var ingredient = await _dbContext.Ingredients.FindAsync(id, ct);
        if (ingredient is null)
        {
            return null;
        }
        ingredient.EdibleRaw = newEdibility;
        return ingredient;
    }
    public async Task<Ingredient?> UpdateScoreAsync(string ingredientId, string newScoreId, CancellationToken ct = default)
    {
        var ingredient = await _dbContext.Ingredients.FindAsync(ingredientId, ct);
        if (ingredient is null)
        {
            return null;
        }
        ingredient.ScoreId = newScoreId;
        return ingredient;
    }
    #endregion
    #region Delete methods
    public void Remove(Ingredient ingredient)
    {
        _dbContext.Ingredients.Remove(ingredient);
    }
    #endregion
}