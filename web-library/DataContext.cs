using Microsoft.EntityFrameworkCore;

namespace web_library
{
    using Api.Book.Entity;
    using Api.Genre.Entity;
    using Api.User.Entity;
    using Api.BookReservation.Entity;

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
            modelBuilder.Entity<Book>()
                .HasMany(left => left.Genres)
                .WithMany(right => right.Books)
                .UsingEntity<Dictionary<string, object>>(
                "book_genres",
                j => j.HasOne<Genre>().WithMany().HasForeignKey("genre_id"),
                j => j.HasOne<Book>().WithMany().HasForeignKey("book_id")
            );

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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }


        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BooksCopy { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<UserBasicInfo> UserBasicInfos { get; set; }
    }
}