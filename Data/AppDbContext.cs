using Finall_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Finall_ASP.NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<Dish> Dishes => Set<Dish>();
        public DbSet<Order> Orders => Set<Order>();
    }
}