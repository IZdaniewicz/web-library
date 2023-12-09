﻿using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.Genre.Entity;

using Book.Entity;
using web_library.Book.Entity;

[Table("genres")]
public class Genre
{
<<<<<<< HEAD
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
=======
    [Table("genres")]
    public class Genre
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")] public string Name { get; set; }
        public List<Book.Entity.Book> Books { get; }

        public Genre()
        {
            Books = new List<Book.Entity.Book>();
        }

        public Genre(string name)
        {
            Name = name;
            Books = new List<Book.Entity.Book>();
        }
    }
}
>>>>>>> master
