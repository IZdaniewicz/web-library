using System.ComponentModel.DataAnnotations.Schema;
using web_library;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace web_library.Book.Entity;

public class Book
{
    public int Id { get; set; }
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateOnly Publication_date{ get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public ICollection<BookCopy> Copies { get; } = new List<BookCopy>();

    public Book(string iSBN, string title, string author, string publisher, DateOnly publication_date, string location, string description)
    {
        ISBN = iSBN;
        Title = title;
        Author = author;
        Publisher = publisher;
        Publication_date = publication_date;
        Location = location;
        Description = description;
    }
}