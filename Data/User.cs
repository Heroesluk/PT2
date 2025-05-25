using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PT2.data.API;

namespace PT2.data
{
    [Table("Users")]
    internal class User : IUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public User() { } // Required for EF Core

        public User(int id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public User(IUser user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Username: {Username}, Email: {Email}";
        }
    }
}