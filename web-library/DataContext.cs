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
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book.Entity.Book>()
            .HasMany(left => left.Genres)
            .WithMany(right => right.Books)
            .UsingEntity<Dictionary<string, object>>(
            "book_genres",
            j => j.HasOne<Genre.Entity.Genre>().WithMany().HasForeignKey("genre_id"),
            j => j.HasOne<Book.Entity.Book>().WithMany().HasForeignKey("book_id")
        );

        modelBuilder.Entity<User.Entity.User>(entity =>
        {
            entity.ToTable("users");
            entity.HasIndex(u => u.Email).IsUnique();

            entity.HasOne(u => u.UserBasicInfo)
                .WithOne(ubi => ubi.User)
                .HasForeignKey<User.Entity.UserBasicInfo>(ubi => ubi.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<User.Entity.UserBasicInfo>(entity =>
        {
            entity.ToTable("user_basic_info");

            entity.Property(ubi => ubi.UserId).IsRequired();

            entity.HasIndex(ubi => ubi.UserId).IsUnique();

        });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User.Entity.User> Users { get; set; }
    public DbSet<Book.Entity.Book> Books { get; set; }
    public DbSet<Book.Entity.BookCopy> BooksCopy { get; set; }
    public DbSet<Genre.Entity.Genre> Genres { get; set; }
    public DbSet<Reservation.Entity.Reservation> Reservations { get; set; }
    public DbSet<User.Entity.UserBasicInfo> UserBasicInfos { get; set; }
}