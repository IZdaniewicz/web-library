using Microsoft.EntityFrameworkCore;
using web_library.Book.Entity;
using web_library.Genre.Entity;
using web_library.Reservation.Entity;
using web_library.Role.Entity;
using web_library.User.Entity;
public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Book>()
        //    .HasMany(left => left.Genres)
        //    .WithMany(right => right.Books)
        //    .UsingEntity<Dictionary<string, object>>(
        //    "book_genres",
        //    j => j.HasOne<Genre>().WithMany().HasForeignKey("genre_id"),
        //    j => j.HasOne<Book>().WithMany().HasForeignKey("book_id")
        //);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasIndex(u => u.Email).IsUnique();

            entity.HasOne(u => u.UserBasicInfo)
                .WithOne(ubi => ubi.User)
                .HasForeignKey<UserBasicInfo>(ubi => ubi.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<UserBasicInfo>(entity =>
        {
            entity.ToTable("user_basic_info");

            entity.Property(ubi => ubi.UserId).IsRequired();

            entity.HasIndex(ubi => ubi.UserId).IsUnique();
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");
            entity.HasKey(r => r.Id);
        });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookCopy> BooksCopy { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<UserBasicInfo> UserBasicInfos { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Reservation> Reservations{ get; set; }
}