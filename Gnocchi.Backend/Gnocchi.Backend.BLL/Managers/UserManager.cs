using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.BLL.Interfaces;

namespace Gnocchi.Backend.BLL.Managers;

public class UserManager : IUserManager
{
    #region Fields
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    #endregion
    #region Constructors
    public UserManager(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    #endregion
    #region Create methods
    public async Task AddAsync(User user, CancellationToken ct = default)
    {
        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(ct);
    }
    #endregion
    #region Read methods
    public async Task<IReadOnlyList<User>?> GetAllAsync(CancellationToken ct = default)
    {
        return await _userRepository.GetAllAsync(ct);
    }
    public async Task<User?> GetAsync(string id, CancellationToken ct = default)
    {
        return await _userRepository.GetAsync(id, ct);
    }
    public async Task<User?> GetCompleteAsync(string id, CancellationToken ct = default)
    {
        return await _userRepository.GetFullAsync(id, ct);
    }
    #endregion
    #region Update methods
    #endregion
    #region Delete methods
    public async Task RemoveAsync(User user, CancellationToken ct = default)
    {
        _userRepository.Remove(user);
        await _unitOfWork.SaveChangesAsync(ct);
    }
    #endregion
}