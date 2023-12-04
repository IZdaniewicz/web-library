using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.Api.Genre.Entity;

using Book.Entity;
[Table("genres")]
public class Genre
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    public List<Book> Books { get; }
    public Genre()
    {
        Books = new List<Book>();
    }

    public Genre(string name)
    {
        Name = name;
    }

}
