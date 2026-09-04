namespace Gnocchi.Backend.DAL.Repositories;

public class RecipeStepRepository : IRecipeStepRepository
{
    // TODO! Check if junction tables need manager classes
    #region Fields
    private readonly GnocchiDbContext _dbContext;
    #endregion
    #region Constructors
    public RecipeStepRepository(GnocchiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion
    #region Create methods
    public void Add(RecipeStep recipeStep)
    {
        _dbContext.RecipeSteps.Add(recipeStep);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<RecipeStep>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbContext.RecipeSteps.AsNoTracking().ToListAsync(ct);
    }
    public async Task<RecipeStep?> GetAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.RecipeSteps.FindAsync(id, ct);
    }
    public async Task<RecipeStep?> GetFullAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.RecipeSteps
        .Where(rs => rs.RecipeStepId == id)
        .Include(rs => rs.Dish)
        .Include(rs => rs.Result)
        .AsNoTracking()
        .AsSplitQuery()
        .FirstOrDefaultAsync(ct);
    }
    public async Task<RecipeStep?> GetWithDishAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.RecipeSteps
        .Where(rs => rs.RecipeStepId == id)
        .Include(rs => rs.Dish)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    public async Task<RecipeStep?> GetWithResultAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.RecipeSteps
        .Where(rs => rs.RecipeStepId == id)
        .Include(rs => rs.Result)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    #endregion
    #region Update methods
    #endregion
    #region Delete methods
    public void Remove(RecipeStep recipeStep)
    {
        _dbContext.RecipeSteps.Remove(recipeStep);
    }
    #endregion
}