using System.ComponentModel.DataAnnotations.Schema;
namespace web_library.Book.Entity;

using Microsoft.VisualBasic;
using web_library.Genre.Entity;

[Table("books")]
public class Book
{
    [Column("id")]
    public int Id { get; set; }
    [Column("isbn")]
    public string ISBN { get; set; }
    [Column("title")]
    public string Title { get; set; }
    [Column("author")]
    public string Author { get; set; }
    [Column("publisher")]
    public string Publisher { get; set; }
    [Column("publication_date")]
    public DateOnly Publication_date{ get; set; }
    [Column("location")]
    public string Location { get; set; }
    [Column("description")]
    public string Description { get; set; }
    public ICollection<BookCopy> Copies { get; }
    public ICollection<Genre> Genres { get; }

    public Book() {
        Genres = new List<Genre>();
        Copies = new List<BookCopy>();
    }

    public Book(string iSBN, string title, string author, string publisher, DateOnly publication_date, string location, string description)
    {
        ISBN = iSBN;
        Title = title;
        Author = author;
        Publisher = publisher;
        Publication_date = publication_date;
        Location = location;
        Description = description;
        Genres = new List<Genre>();
        Copies = new List<BookCopy>();
    }

    public void AddGenre(Genre genre)
    {
        this.Genres.Add(genre);
    }


}