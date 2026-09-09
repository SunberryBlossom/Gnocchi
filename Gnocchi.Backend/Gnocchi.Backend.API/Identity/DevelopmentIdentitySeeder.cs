using Microsoft.AspNetCore.Identity;
using Gnocchi.Backend.Models;

namespace Gnocchi.Backend.API.Identity;

public static class DevelopmentIdentitySeeder
{
    public static async Task SeedAsync(
        IServiceProvider services,
        IConfiguration configuration,
        ILogger logger,
        CancellationToken cancellationToken = default)
    {
        var settings = configuration.GetSection("SeedData");
        var adminEmail = settings["AdminEmail"] ?? throw new InvalidOperationException("SeedData:AdminEmail is required.");
        var adminPassword = settings["AdminPassword"] ?? throw new InvalidOperationException("SeedData:AdminPassword is required.");
        var testUserEmail = settings["TestUserEmail"] ?? throw new InvalidOperationException("SeedData:TestUserEmail is required.");
        var testUserPassword = settings["TestUserPassword"] ?? throw new InvalidOperationException("SeedData:TestUserPassword is required.");

        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<User>>();

        if (!await roleManager.RoleExistsAsync("admin"))
        {
            var roleResult = await roleManager.CreateAsync(new IdentityRole("admin"));
            EnsureSucceeded(roleResult, "admin role");
        }

        var admin = await EnsureUserAsync(userManager, adminEmail, adminPassword, cancellationToken);
        if (!await userManager.IsInRoleAsync(admin, "admin"))
        {
            var roleResult = await userManager.AddToRoleAsync(admin, "admin");
            EnsureSucceeded(roleResult, $"assigning admin role to {adminEmail}");
        }

        await EnsureUserAsync(userManager, testUserEmail, testUserPassword, cancellationToken);
        logger.LogInformation("Development Identity seed completed for {AdminEmail} and {TestUserEmail}.", adminEmail, testUserEmail);
    }

    private static async Task<User> EnsureUserAsync(
        UserManager<User> userManager,
        string email,
        string password,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user is not null)
        {
            return user;
        }

        user = new User
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, password);
        EnsureSucceeded(result, $"creating {email}");
        return user;
    }

    private static void EnsureSucceeded(IdentityResult result, string operation)
    {
        if (result.Succeeded)
        {
            return;
        }

        var errors = string.Join("; ", result.Errors.Select(error => error.Description));
        throw new InvalidOperationException($"Identity seed failed while {operation}: {errors}");
    }
}
