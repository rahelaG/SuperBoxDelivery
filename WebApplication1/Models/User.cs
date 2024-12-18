namespace WebApplication1.Models;

public class User
{
    public string UserName {get; }
    protected string Password {get; }
    protected string Mail { get; }

    public User(string userName, string password, string mail)
    {
        UserName = userName;
        Password = password;
        Mail = mail;
    }

    public override string ToString()
    {
        return $"Username:{UserName}, Password:{Password}, Mail:{Mail}";
    }
}