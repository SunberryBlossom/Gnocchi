namespace Gnocchi.Backend.BLL.Interfaces;

public interface ICurrentUserAccessor
{
    string? UserId { get; }
    bool IsAdmin { get; }
}
