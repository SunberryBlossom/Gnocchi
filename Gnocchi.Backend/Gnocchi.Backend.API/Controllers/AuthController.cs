using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(SignInManager<User> signInManager) : ControllerBase
{
    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return NoContent();
    }
}