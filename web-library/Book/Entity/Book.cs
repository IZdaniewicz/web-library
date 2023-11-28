using System.ComponentModel.DataAnnotations.Schema;
using web_library;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace web_library.Book.Entity;

[Table("books")]
public class Book
{
    [Column(name: "id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "isbn")]
    public string ISBN { get; set; }

    [Column(name: "title")]
    public string Title { get; set; }

    [Column(name: "author")]
    public string Author { get; set; }

    [Column(name: "publisher")]
    public string Publisher { get; set; }

    [Column(name: "publication_date")]
    public DateOnly Publication_date{ get; set; }

    [Column(name: "location")]
    public string Location { get; set; }

    [Column(name: "description")]
    public string Description { get; set; }

    public Book(string iSBN, string title, string author, string publisher, DateOnly publication_date, string location, string description = "")
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