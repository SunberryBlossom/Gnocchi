namespace Gnocchi.Backend.BLL.Interfaces;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken ct = default);
}