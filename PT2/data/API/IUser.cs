namespace PT2.data.API;

public interface IUser
{
    int Id { get; set; }
    string Username { get; set; }
    string Password { get; set; }
    string Email { get; set; }
    
    
}