namespace WebApplication1.Models;

public class SuperBox
{   
    public string Id { get; set; }
    public int AddressId { get; set; } 
    public int Capacity { get; set; }
    public List<Order> OrderList;

    public SuperBox() { }
    public SuperBox(string idSuperBox, int capacity, int addressId)
    {
        Id = idSuperBox;
        Capacity = capacity;
        AddressId = addressId;
        OrderList = new List<Order>();
    }
}