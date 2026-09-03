using Gnocchi.Backend.Bll.Interfaces;
using Gnocchi.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Gnocchi.Backend.DAL.Repositories;

public class CookingMethodRepository : ICookingMethodRepository
{
    #region Fields
    private readonly GnocchiDbContext _dbContext;
    #endregion
    #region Constructors
    public CookingMethodRepository(GnocchiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion
    #region Create methods
    public void Add(CookingMethod cookingMethod)
    {
        _dbContext.CookingMethods.Add(cookingMethod);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<CookingMethod>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbContext.CookingMethods.AsNoTracking().ToListAsync(ct);
    }
    public async Task<CookingMethod?> GetAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.CookingMethods.FindAsync(id, ct);
    }

    public async Task<CookingMethod?> GetFullAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.CookingMethods
        .Where(cm => cm.CookingMethodId == id)
        .Include(cm => cm.Score)
        .Include(cm => cm.Results)
        .AsNoTracking()
        .AsSplitQuery()
        .FirstOrDefaultAsync(ct);
    }

    public async Task<CookingMethod?> GetWithResultsAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.CookingMethods
        .Where(cm => cm.CookingMethodId == id)
        .Include(cm => cm.Results)
        .FirstOrDefaultAsync(ct);
    }

    public async Task<CookingMethod?> GetWithScoreAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.CookingMethods
        .Where(cm => cm.CookingMethodId == id)
        .Include(cm => cm.Score)
        .FirstOrDefaultAsync(ct);
    }
    #endregion
    #region Update methods
    public async Task<CookingMethod?> UpdateScoreAsync(string cookingMethodId, string newScoreId, CancellationToken ct = default)
    {
        var cookingMethod = await _dbContext.CookingMethods.FindAsync(cookingMethodId, ct);

        if (cookingMethod is null)
        {
            return null;
        }

        cookingMethod.ScoreId = newScoreId;
        return cookingMethod;
    }
    #endregion
    #region Delete methods
    public void Remove(CookingMethod cookingMethod)
    {
        _dbContext.CookingMethods.Remove(cookingMethod);
    }
    #endregion

}