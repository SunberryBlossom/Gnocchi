using Gnocchi.Backend.App.Services;
using Gnocchi.Backend.BLL.Interfaces;
namespace Gnocchi.Backend.BLL.Services;

public class DishManager : IDishManager
{
    private readonly IDishRepository _dishRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DishManager(IDishRepository dishRepository, IUnitOfWork unitOfWork)
    {
        _dishRepository = dishRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task AddAsync(Dish dish, CancellationToken ct = default)
    {
        _dishRepository.Add(dish);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task<Dish> GetByIdAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dish> GetCompleteByIdAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dish> GetWithSpecificEntityAsync(string id, string entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Dish dish)
    {
        throw new NotImplementedException();
    }

    public Task<Dish> UpdateAsync(string id, string attribute, string newValue, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}