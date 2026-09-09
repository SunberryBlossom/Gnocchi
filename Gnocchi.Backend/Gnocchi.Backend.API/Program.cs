using Gnocchi.Backend.API.Interfaces;
using Gnocchi.Backend.API.Identity;
using Gnocchi.Backend.App.Interfaces;
using Gnocchi.Backend.App.Services;
using Gnocchi.Backend.BLL.Interfaces;
using Gnocchi.Backend.BLL.Managers;
using Gnocchi.Backend.DAL;
using Gnocchi.Backend.DAL.Repositories;
using Gnocchi.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Gnocchi.Backend.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        #region Service container configuration
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection must be configured through user secrets or the deployment environment.");
        var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];

        builder.Services.AddDbContext<GnocchiDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddCors(options => options.AddPolicy("Frontend", policy =>
            policy.WithOrigins(allowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()));
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<ICurrentUserAccessor, HttpCurrentUserAccessor>();
        builder.Services.AddScoped<IUnitOfWork>(services => services.GetRequiredService<GnocchiDbContext>());
        builder.Services.AddIdentityApiEndpoints<User>(options => options.User.RequireUniqueEmail = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<GnocchiDbContext>();
        builder.Services.AddControllers();
        builder.Services.AddExceptionHandler(exceptionOptions =>
        {
            exceptionOptions.ExceptionHandler = async context =>
            {
                var exception = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;
                context.Response.StatusCode = exception is NullReferenceException ? StatusCodes.Status404NotFound : StatusCodes.Status500InternalServerError;
                await context.Response.CompleteAsync();
            };
        });
        builder.Services.AddProblemDetails();
        builder.Services.AddOpenApi();
        builder.Services.AddAuthorization();
        #region Repositories
        builder.Services.AddScoped<IDishRepository, DishRepository>();
        builder.Services.AddScoped<ICookingMethodRepository, CookingMethodRepository>();
        builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
        builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
        builder.Services.AddScoped<IVariantRepository, VariantRepository>();
        builder.Services.AddScoped<IRecipeStepRepository, RecipeStepRepository>();
        builder.Services.AddScoped<IResultRepository, ResultRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        #endregion
        #region Managers
        builder.Services.AddScoped<IDishManager, DishManager>();
        builder.Services.AddScoped<ICookingMethodManager, CookingMethodManager>();
        builder.Services.AddScoped<IIngredientManager, IngredientManager>();
        builder.Services.AddScoped<IResultManager, ResultManager>();
        builder.Services.AddScoped<IScoreManager, ScoreManager>();
        builder.Services.AddScoped<IUserManager, UserManager>();
        builder.Services.AddScoped<IVariantManager, VariantManager>();
        #endregion
        #endregion
        #region Services
        builder.Services.AddScoped<IDishService, DishService>();
        builder.Services.AddScoped<IVariantService, VariantService>();
        builder.Services.AddScoped<IScoreService, ScoreService>();
        builder.Services.AddScoped<ICookingMethodService, CookingMethodService>();
        builder.Services.AddScoped<IIngredientService, IngredientService>();
        builder.Services.AddScoped<IResultService, ResultService>();
        #endregion
        #region Middleware configuration
        var app = builder.Build();
        app.UseExceptionHandler();
        if (app.Environment.IsDevelopment())
        {
            using var scope = app.Services.CreateScope();
            try
            {
                await DevelopmentIdentitySeeder.SeedAsync(scope.ServiceProvider, builder.Configuration, app.Logger);
            }
            catch (Exception exception)
            {
                app.Logger.LogWarning(exception, "Could not provision development Identity seed data during startup.");
            }
        }
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }
        app.UseHttpsRedirection();
        app.UseCors("Frontend");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapIdentityApi<User>();
        app.MapControllers();
        await app.RunAsync();
        #endregion
    }
}
