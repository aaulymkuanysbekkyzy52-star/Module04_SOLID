public class OrderItem
{
    public string ProductName { get; }
    public int Quantity { get; }
    public double Price { get; }

    public OrderItem(string productName, int quantity, double price)
    {
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }

    public double GetTotalPrice() => Quantity * Price;
}
