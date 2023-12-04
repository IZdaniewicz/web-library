using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.Api.Book.Entity;
using Reservation.Entity;

[Table("book_copies")]
public class BookCopy
{
    [Column("id")]
    public int Id { get; set; }
    [Column("book_id")]
    public int BookId { get; set; }
    public Book Book { get; set; }
    public Reservation? reservation { get; set; }
    public BookCopy() { }
    public BookCopy(Book book)
    {
        Book = book;
    }
}

