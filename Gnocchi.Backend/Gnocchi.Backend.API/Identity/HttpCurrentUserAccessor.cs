using System.Security.Claims;
using Gnocchi.Backend.BLL.Interfaces;

namespace Gnocchi.Backend.API.Identity;

public sealed class HttpCurrentUserAccessor(IHttpContextAccessor httpContextAccessor) : ICurrentUserAccessor
{
    public string? UserId => httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

    public bool IsAdmin => httpContextAccessor.HttpContext?.User.IsInRole("admin") == true;
}
