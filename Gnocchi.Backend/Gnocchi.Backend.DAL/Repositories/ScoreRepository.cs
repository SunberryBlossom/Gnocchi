namespace Gnocchi.Backend.DAL.Repositories;

public class ScoreRepository : IScoreRepository
{
    #region Fields
    private readonly GnocchiDbContext _dbContext;
    #endregion
    #region Constructors
    public ScoreRepository(GnocchiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion
    #region Create methods
    public void Add(Score score)
    {
        _dbContext.Scores.Add(score);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<Score>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbContext.Scores.ToListAsync(ct);
    }
    public async Task<Score?> GetAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Scores.FindAsync(id, ct);
    }
    public async Task<Score?> GetFullAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Scores
        .Where(score => score.ScoreId == id)
        .Include(score => score.CookingMethods)
        .Include(score => score.Dishes)
        .Include(score => score.Ingredients)
        .AsNoTracking()
        .AsSplitQuery()
        .FirstOrDefaultAsync(ct);
    }
    public async Task<Score?> GetWithCookingMethodsAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Scores
        .Where(score => score.ScoreId == id)
        .Include(score => score.CookingMethods)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    public async Task<Score?> GetWithDishesAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Scores
        .Where(score => score.ScoreId == id)
        .Include(score => score.Dishes)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    public async Task<Score?> GetWithIngredientsAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Scores
        .Where(score => score.ScoreId == id)
        .Include(score => score.Ingredients)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    #endregion
    #region Update methods
    #endregion
    #region Delete methods
    public async void Remove(Score score)
    {
        _dbContext.Scores.Remove(score);
    }
    #endregion
}