using Microsoft.EntityFrameworkCore;
namespace web_library;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //todo
    }

    public DbSet<Book.Entity.Book> Books { get; set; }
}