namespace WebApplication1.Models;

public class SuperBox
{
    protected string IdSuperBox { get; set; }
    protected Address AddressSuperBox { get; set; }
    protected int Capacity { get; set; }
    protected List<Order> OrderList;

    public SuperBox(string idSuperBox, Address addressSuperBox, int capacity)
    {
        IdSuperBox = idSuperBox;
        AddressSuperBox = addressSuperBox;
        Capacity = capacity;
        OrderList = new List<Order>();
    }
}