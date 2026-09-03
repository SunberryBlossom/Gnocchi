using Gnocchi.Backend.Bll.Interfaces;
using Gnocchi.Backend.DAL;
using Gnocchi.Backend.DAL.Repositories;
using Gnocchi.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gnocchi.Backend.API;

public class Program
{
    public static void Main(string[] args)
    {
        #region Service container configuration
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<GnocchiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddIdentityApiEndpoints<User>(options => options.User.RequireUniqueEmail = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<GnocchiDbContext>();
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddAuthorization();
        builder.Services.AddScoped<IDishRepository, DishRepository>();
        builder.Services.AddScoped<ICookingMethodRepository, CookingMethodRepository>();
        builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
        builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
        builder.Services.AddScoped<IVariantRepository, VariantRepository>();
        builder.Services.AddScoped<IRecipeStepRepository, RecipeStepRepository>();
        builder.Services.AddScoped<IResultRepository, ResultRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        #endregion
        #region Middleware configuration
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapIdentityApi<User>();
        app.MapControllers();
        app.Run();
        #endregion
    }
}
