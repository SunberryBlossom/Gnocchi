namespace Gnocchi.Backend.DAL.Repositories;

public class VariantRepository : IVariantRepository
{
    #region Fields
    private readonly GnocchiDbContext _dbContext;
    #endregion
    #region Constructors
    public VariantRepository(GnocchiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion
    #region Create methods
    public void Add(Variant variant)
    {
        _dbContext.Variants.Add(variant);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<Variant>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbContext.Variants.ToListAsync(ct);
    }
    public async Task<Variant?> GetAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Variants.FindAsync(id, ct);
    }
    public async Task<Variant?> GetWithDishesAsync(string id, CancellationToken ct = default)
    {
        return await _dbContext.Variants
        .Where(variant => variant.VariantId == id)
        .Include(variant => variant.Dishes)
        .AsNoTracking()
        .FirstOrDefaultAsync(ct);
    }
    #endregion
    #region Update methods
    #endregion
    #region Delete methods
    public void Remove(Variant variant)
    {
        _dbContext.Variants.Remove(variant);
    }
    #endregion
}