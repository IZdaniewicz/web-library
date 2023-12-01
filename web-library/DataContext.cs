using Microsoft.EntityFrameworkCore;
using System.Drawing;
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
        modelBuilder.Entity<web_library.Book.Entity.Book>()
            .HasMany(left => left.Genres)
            .WithMany(right => right.Books)
                    //.UsingEntity(join => join.ToTable("book_genres"));
            .UsingEntity<Dictionary<string, object>>(
            "book_genres", // Name of the join table
            j => j.HasOne<Genre.Entity.Genre>().WithMany().HasForeignKey("genre_id"), // Replace "NewGenreId" with your desired column name for GenreId
            j => j.HasOne<Book.Entity.Book>().WithMany().HasForeignKey("book_id") // Replace "NewBookId" with your desired column name for BookId
        );
    }

    public DbSet<Book.Entity.Book> Books { get; set; }
    public DbSet<Book.Entity.BookCopy> BooksCopy { get; set; }
    public DbSet<Genre.Entity.Genre> Genres { get; set; }

}
