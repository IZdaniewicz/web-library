using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.Book.Entity;

[Table("books_copies")]
public class BookCopy
{
    [Column(name: "id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "book_id")]
    public int BookId { get; set; }
    public Book Book { get; set; }

    public BookCopy(int bookId)
    {
        BookId = bookId;
    }
}

