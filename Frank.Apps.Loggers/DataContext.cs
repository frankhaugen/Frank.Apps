using Frank.Apps.Loggers.LoggingProviders.Shared;
using Microsoft.EntityFrameworkCore;

namespace Frank.Apps.Loggers;

public class DataContext : DbContext
{
    public DbSet<Log> Logs { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LoggingDatabase;Trusted_Connection=True;");
    //    base.OnConfiguring(optionsBuilder);
    //}
}