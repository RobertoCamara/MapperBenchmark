namespace ObjectMapping.Benchmark.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public OrderStatus Status { get; set; }

    public Customer Customer { get; set; } = new();
    public Address ShippingAddress { get; set; } = new();
    public List<OrderItem> Items { get; set; } = [];
    public decimal TotalAmount { get; set; }
}
