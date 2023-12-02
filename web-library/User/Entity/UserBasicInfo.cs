using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.User.Entity;

[Table("user_basic_info")]
public class UserBasicInfo
{
    [Column(name: "id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "userId")] public int UserId { get; set; }

    [Column(name: "first_name")] public string FirstName { get; set; }

    [Column(name: "last_name")] public string LastName { get; set; }

    [Column(name: "phone_number")] public string PhoneNumber { get; set; }

    [Column(name: "address")] public string Address { get; set; }

    public User User { get; set; } = null!;

    public UserBasicInfo()
    {
    }

    public UserBasicInfo(int userId, string firstName, string lastName, string phoneNumber, string address,
        User user)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Address = address;
        User = user;
    }
}