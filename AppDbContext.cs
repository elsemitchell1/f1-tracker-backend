using F1TrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace F1TrackerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteDriver> FavoriteDrivers { get; set; }
    }
}