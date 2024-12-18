namespace WebApplication1.Models;

public class Admin : User
{
    public bool IsApproved { get; set; }
    public Admin(string userName, string password, string mail, bool isApproved = false)
        : base(userName, password, mail)
    {
        IsApproved = isApproved;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nIsApproved: {IsApproved}";
    }
}