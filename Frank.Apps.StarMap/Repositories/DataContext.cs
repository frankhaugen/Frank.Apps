using Frank.Apps.StarMap.Models;
using Microsoft.EntityFrameworkCore;

namespace Frank.Apps.StarMap.Repositories
{
    public class DataContext : DbContext
    {
        public DbSet<Star> Stars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:/repos/frankhaugen/Frank.Apps/Frank.Apps.StarMap/Database.db");
        }
    }
}
