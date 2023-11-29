namespace web_library.Book.Entity;

public class BookCopy
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public BookCopy() { }
    public BookCopy(Book book)
    {
        Book = book;
    }
}

