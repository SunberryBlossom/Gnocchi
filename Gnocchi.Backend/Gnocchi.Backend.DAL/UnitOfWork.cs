namespace Gnocchi.Backend.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly GnocchiDbContext _dbContext;
    public UnitOfWork(GnocchiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _dbContext.SaveChangesAsync(ct);
    }
}