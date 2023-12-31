using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.Book.Entity;

[Table("books")]
public class Book
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("isbn")] public string ISBN { get; set; }
    [Column("title")] public string Title { get; set; }
    [Column("author")] public string Author { get; set; }
    [Column("publisher")] public string Publisher { get; set; }
    [Column("publication_date")] public DateOnly Publication_date { get; set; }
    [Column("location")] public string Location { get; set; }
    [Column("description")] public string Description { get; set; }
    public ICollection<BookCopy> Copies { get; }
    public ICollection<Genre.Entity.Genre> Genres { get; }

    public Book()
    {
        Genres = new List<Genre.Entity.Genre>();
        Copies = new List<BookCopy>();
    }

    public Book(string iSBN, string title, string author, string publisher, DateOnly publication_date, string location,
        string description)
    {
        ISBN = iSBN;
        Title = title;
        Author = author;
        Publisher = publisher;
        Publication_date = publication_date;
        Location = location;
        Description = description;
        Genres = new List<Genre.Entity.Genre>();
        Copies = new List<BookCopy>();
    }

    public void AddGenre(Genre.Entity.Genre genre)
    {
        this.Genres.Add(genre);
    }
}