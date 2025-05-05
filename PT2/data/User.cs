using System;
using PT2.data.API;

namespace PT2.data
{
    public class User: IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    
        
        public User(int id, string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            Id = id;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Username: {Username}, Email: {Email}";
        }

    }
}
