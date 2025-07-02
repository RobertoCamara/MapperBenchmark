using ObjectMapping.Benchmark.Entities;

namespace ObjectMapping.Benchmark.Dtos;

public record OrderItemDto
{
    public int ProductId { get; init; }
    public string ProductName { get; init; } = string.Empty;
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }

    public static explicit operator OrderItem(OrderItemDto dto)
    {
        return new OrderItem
        {
            ProductId = dto.ProductId,
            ProductName = dto.ProductName,
            Quantity = dto.Quantity,
            UnitPrice = dto.UnitPrice
        };
    }

    public static explicit operator OrderItemDto(OrderItem entity)
    {
        return new OrderItemDto
        {
            ProductId = entity.ProductId,
            ProductName = entity.ProductName,
            Quantity = entity.Quantity,
            UnitPrice = entity.UnitPrice
        };
    }
}

