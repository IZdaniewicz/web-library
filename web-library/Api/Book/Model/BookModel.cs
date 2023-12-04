namespace web_library.Api.Book.Model;

public class BookModel
{
    public int BookId { get; set; }
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateOnly Publication_date { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public int NumberOfCopies { get; set; }

    public BookModel(int bookId, string iSBN, string title, string author, string publisher, DateOnly publication_date, string location, string description, int numberOfCopies)
    {
        BookId = bookId;
        ISBN = iSBN;
        Title = title;
        Author = author;
        Publisher = publisher;
        Publication_date = publication_date;
        Location = location;
        Description = description;
        NumberOfCopies = numberOfCopies;
    }
}
