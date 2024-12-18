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

    public Order(string idOrder, User userSender, User userReceiver, bool isUrgent, bool orderStatus)
    {
        IdOrder = idOrder;
        UserSender = userSender;
        UserReceiver = userReceiver;
        IsUrgent = isUrgent;
        OrderStatus = orderStatus;
    }
}
