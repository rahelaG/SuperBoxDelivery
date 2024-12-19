namespace WebApplication1.Models;
public enum OrderStatus
{
    InLocker,
    Delivered
}
public class Order
{
    protected string IdOrder { get; set; }
    protected User UserSender { get; set; }
    protected User UserReceiver { get; set; }
    protected bool IsUrgent { get; set; }
    protected bool OrderStatus { get; set; }
    protected Address AddressSender { get; set; }
    protected Address AddressReceiver { get; set; }

    public Order(string idOrder, User userSender, User userReceiver, bool isUrgent, bool orderStatus, Address addressSender, Address addressReceiver)
    {
        IdOrder = idOrder;
        UserSender = userSender;
        UserReceiver = userReceiver;
        IsUrgent = isUrgent;
        OrderStatus = orderStatus;
        AddressSender = addressSender;
        AddressReceiver = addressReceiver;
    }
}
