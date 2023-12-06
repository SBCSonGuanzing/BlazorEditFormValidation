global using BlazorPlayGround.Shared.Models;
global using Microsoft.EntityFrameworkCore;

namespace BlazorWebAPI.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        // Add database set
        public DbSet<Character> Characters { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Difficulty> Difficulties { get; set; }

    }
}
