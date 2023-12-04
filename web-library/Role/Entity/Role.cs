using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.Role.Entity;

[Table("roles")]
public class Role
{
    [Column(name: "id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "name")] public string Name { get; set; }
}