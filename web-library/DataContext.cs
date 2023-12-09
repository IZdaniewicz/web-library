using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======
using web_library.Book.Entity;
using web_library.User.Entity;

>>>>>>> master
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
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<Role.Entity.Role>(entity =>
        {
            entity.ToTable("roles");
            entity.HasKey(r => r.Id);
        });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User.Entity.User> Users { get; set; }
    public DbSet<Book.Entity.Book> Books { get; set; }
    public DbSet<BookCopy> BooksCopy { get; set; }
    public DbSet<Genre.Entity.Genre> Genres { get; set; }
<<<<<<< HEAD
    public DbSet<Reservation.Entity.Reservation> Reservations { get; set; }
    public DbSet<User.Entity.UserBasicInfo> UserBasicInfos { get; set; }
=======
    public DbSet<UserBasicInfo> UserBasicInfos { get; set; }
    public DbSet<Role.Entity.Role> Roles { get; set; }
>>>>>>> master
}