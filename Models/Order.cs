using System.Collections.Generic;
using System.Linq;

public class Order
{
    private readonly List<OrderItem> _items = new();

    public IPayment PaymentMethod { get; set; }
    public IDelivery DeliveryMethod { get; set; }

    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }

    public double GetTotalPrice()
    {
        return _items.Sum(i => i.GetTotalPrice());
    }
}
