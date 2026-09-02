using Gnocchi.Backend.Bll.Interfaces;
using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.DAL.Repositories;

public class DishRepository : IDishRepository
{
    public Task AddAsync(Dish dish, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Dish>> GetAllAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dish?> GetAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dish?> GetFullAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dish?> GetwithRecipeStepsAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dish?> GetWithScoreAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dish?> GetWithVariantAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dish?> UpdateNameAsync(string id, string newName, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dish?> UpdateScoreAsync(string dishId, string newScoreId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dish?> UpdateVariantAsync(string dishId, string newVariantId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}