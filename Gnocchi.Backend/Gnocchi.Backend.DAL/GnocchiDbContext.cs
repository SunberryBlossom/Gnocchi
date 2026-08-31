using Gnocchi.Backend.Models;
using Microsoft.EntityFrameworkCore; // To use DbContext superclass

namespace Gnocchi.Backend.DAL;

public class GnocchiDbContext : DbContext
{
    #region Constructors
    public GnocchiDbContext(DbContextOptions<GnocchiDbContext> options) : base(options) { }
    #endregion

    #region DBSets
    public DbSet<Dish> Dishes { get; set; }
    #endregion
}