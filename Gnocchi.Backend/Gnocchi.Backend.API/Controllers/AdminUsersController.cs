using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.API.Controllers;

[ApiController]
[Route("api/admin/users")]
[Authorize(Roles = "admin")]
public sealed class AdminUsersController(
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AdminUserResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var users = await userManager.Users
            .AsNoTracking()
            .Select(user => new AdminUserResponse(user.Id, user.UserName!, user.Email!, user.EmailConfirmed))
            .ToListAsync(cancellationToken);

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AdminUserResponse>> GetById(string id, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(id);
        return user is null
            ? NotFound()
            : Ok(await ToResponseAsync(user));
    }

    [HttpPost]
    public async Task<ActionResult<AdminUserResponse>> Create(
        [FromBody] CreateAdminUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = new User { UserName = request.Email, Email = request.Email };
        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        if (request.Roles is not null)
        {
            foreach (var role in request.Roles.Distinct(StringComparer.OrdinalIgnoreCase))
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    return BadRequest($"Role '{role}' does not exist.");
                }
            }

            var roleResult = await userManager.AddToRolesAsync(user, request.Roles);
            if (!roleResult.Succeeded)
            {
                return BadRequest(roleResult.Errors);
            }
        }

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, await ToResponseAsync(user));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AdminUserResponse>> Update(
        string id,
        [FromBody] UpdateAdminUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        user.Email = request.Email;
        user.UserName = request.Email;
        user.EmailConfirmed = request.EmailConfirmed;
        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        if (request.Roles is not null)
        {
            var roles = request.Roles.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    return BadRequest($"Role '{role}' does not exist.");
                }
            }

            var currentRoles = await userManager.GetRolesAsync(user);
            var removeResult = await userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
            {
                return BadRequest(removeResult.Errors);
            }

            var addResult = await userManager.AddToRolesAsync(user, roles);
            if (!addResult.Succeeded)
            {
                return BadRequest(addResult.Errors);
            }
        }

        return Ok(await ToResponseAsync(user));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        var result = await userManager.DeleteAsync(user);
        return result.Succeeded ? NoContent() : BadRequest(result.Errors);
    }

    private async Task<AdminUserResponse> ToResponseAsync(User user)
    {
        var roles = await userManager.GetRolesAsync(user);
        return new AdminUserResponse(user.Id, user.UserName!, user.Email!, user.EmailConfirmed, roles.ToArray());
    }
}

public sealed record CreateAdminUserRequest(string Email, string Password, IReadOnlyList<string>? Roles);
public sealed record UpdateAdminUserRequest(string Email, bool EmailConfirmed, IReadOnlyList<string>? Roles);
public sealed record AdminUserResponse(
    string Id,
    string UserName,
    string Email,
    bool EmailConfirmed,
    IReadOnlyList<string>? Roles = null);
