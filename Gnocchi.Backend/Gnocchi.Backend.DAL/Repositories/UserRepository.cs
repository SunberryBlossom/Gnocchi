namespace Gnocchi.Backend.DAL.Repositories;

public class UserRepository : IUserRepository
{
    #region Fields
    private readonly GnocchiDbContext _dbContext;
    #endregion
    #region Constructors
    public UserRepository(GnocchiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion
    #region Create methods
    public void Add(User user)
    {
        _dbContext.Users.Add(user);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbContext.Users.ToListAsync(ct);
    }
    public async Task<User?> GetAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Users.FindAsync(id, ct);
    }
    public async Task<User?> GetFullAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Users
        .Where(user => user.Id == id)
        .Include(user => user.CookingMethods)
        .Include(user => user.Ingredients)
        .Include(user => user.Dishes)
        .Include(user => user.Results)
        .Include(user => user.Scores)
        .Include(user => user.Variants)
        .AsNoTracking()
        .AsSplitQuery()
        .FirstOrDefaultAsync(ct);
    }
    #endregion
    #region Update methods
    #endregion
    #region Delete metheods
    public void Remove(User user)
    {
        _dbContext.Users.Remove(user);
    }
    #endregion
}