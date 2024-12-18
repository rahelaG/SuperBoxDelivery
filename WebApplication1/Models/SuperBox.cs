namespace WebApplication1.Models;

public class SuperBox
{
    protected string IdSuperBox { get; set; }
    protected Adress AdressSuperBox { get; set; }
    protected int Capacity { get; set; }
    protected List<Order> OrderList;

    public SuperBox(string idSuperBox, Adress adressSuperBox, int capacity)
    {
        IdSuperBox = idSuperBox;
        AdressSuperBox = adressSuperBox;
        Capacity = capacity;
        OrderList = new List<Order>();
    }
}