using System;

namespace PT2.data
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public override string ToString()
        {
            return $"Username: {Username}, Email: {Email}";
        }
    }
}
