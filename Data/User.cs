using PT2.data.API;

namespace PT2.data
{
    internal class User: IUser
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
