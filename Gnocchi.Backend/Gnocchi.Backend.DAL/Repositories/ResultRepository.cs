namespace Gnocchi.Backend.DAL.Repositories;

public class ResultRepository : IResultRepository
{
    #region Fields
    private readonly GnocchiDbContext _dbContext;
    #endregion
    #region Constructors
    public ResultRepository(GnocchiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion
    #region Create methods
    public void Add(Result result)
    {
        _dbContext.Results.Add(result);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<Result>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbContext.Results.ToListAsync(ct);
    }

    public async Task<Result?> GetAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Results.FindAsync(id, ct);
    }

    public async Task<Result?> GetFullAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Results
        .Where(result => result.ResultId == id)
        .Include(result => result.RecipeSteps)
        .Include(result => result.CookingMethod)
        .Include(result => result.Ingredient)
        .AsNoTracking()
        .AsSplitQuery()
        .FirstOrDefaultAsync(ct);
    }

    public async Task<Result?> GetWithCookingMethodAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Results
        .Where(result => result.ResultId == id)
        .Include(result => result.CookingMethod)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }

    public async Task<Result?> GetWithIngredientAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Results
        .Where(result => result.ResultId == id)
        .Include(result => result.Ingredient)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }

    public async Task<Result?> GetWithRecipeStepsAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Results
        .Where(result => result.ResultId == id)
        .Include(result => result.RecipeSteps)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    #endregion
    #region Update methods
    public async Task<Result?> UpdateCommentAsync(string id, string newComment, CancellationToken ct = default)
    {
        var result = await _dbContext.Results.FindAsync(id, ct);
        if (result is null)
        {
            return null;
        }
        result.Comment = newComment;
        return result;
    }
    #endregion
    #region Delete methods
    public void Remove(Result result)
    {
        _dbContext.Results.Remove(result);
    }
    #endregion


}