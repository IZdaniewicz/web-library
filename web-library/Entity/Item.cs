using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.Entity;

[Table("items")]
public class Item
{
    [Column(name: "id")]
    public int Id { get; set; }
    
    [Column(name: "name")]
    public string Name { get; set; }

    public Item(int id, string name)
    {
        Id = id;
        Name = name;
    }
}