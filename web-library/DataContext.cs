using Microsoft.EntityFrameworkCore;
using web_library.Book.Entity;
using web_library.User.Entity;

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
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User.Entity.User>(entity =>
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
    public DbSet<UserBasicInfo> UserBasicInfos { get; set; }
    public DbSet<Role.Entity.Role> Roles { get; set; }
    public DbSet<Reservation.Entity.Reservation> Reservations{ get; set; }
}