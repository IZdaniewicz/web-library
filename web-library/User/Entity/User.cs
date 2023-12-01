using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.User.Entity;

[Table("users")]
public class User
{
    [Column(name:"id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(name:"email")]
    public string Email { get; set; }

    [Column(name:"password")]
    public string Password { get; set; }

    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }
    
}