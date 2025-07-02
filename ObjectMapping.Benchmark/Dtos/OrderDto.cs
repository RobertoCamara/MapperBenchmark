using ObjectMapping.Benchmark.Entities;

namespace ObjectMapping.Benchmark.Dtos;

public record OrderDto
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public OrderStatus Status { get; init; }

    public CustomerDto Customer { get; init; } = new();
    public AddressDto ShippingAddress { get; init; } = new();
    public List<OrderItemDto> Items { get; init; } = [];
    public decimal TotalAmount { get; init; }

    public static explicit operator Order(OrderDto dto)
    {
        return new Order
        {
            Id = dto.Id,
            CreatedAt = dto.CreatedAt,
            Status = dto.Status,
            Customer = (Customer)dto.Customer,
            ShippingAddress = (Address)dto.ShippingAddress,
            Items = dto.Items.Select(i => (OrderItem)i).ToList(),
            TotalAmount = dto.TotalAmount
        };
    }

    public static explicit operator OrderDto(Order entity)
    {
        return new OrderDto
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Status = entity.Status,
            Customer = (CustomerDto)entity.Customer,
            ShippingAddress = (AddressDto)entity.ShippingAddress,
            Items = entity.Items.Select(i => (OrderItemDto)i).ToList(),
            TotalAmount = entity.TotalAmount
        };
    }


    //public static explicit operator Order(OrderDto dto)
    //{
    //    return new Order
    //    {
    //        Id = dto.Id,
    //        CreatedAt = dto.CreatedAt,
    //        Status = dto.Status,
    //        Customer = new Customer
    //        {
    //            Id = dto.Customer.Id,
    //            FullName = dto.Customer.FullName,
    //            Email = dto.Customer.Email
    //        },
    //        ShippingAddress = new Address
    //        {
    //            Street = dto.ShippingAddress.Street,
    //            City = dto.ShippingAddress.City,
    //            State = dto.ShippingAddress.State,
    //            ZipCode = dto.ShippingAddress.ZipCode
    //        },
    //        Items = [.. dto.Items.Select(i => new OrderItem { ProductId = i.ProductId, ProductName = i.ProductName, Quantity = i.Quantity, UnitPrice = i.UnitPrice })],
    //        TotalAmount = dto.TotalAmount
    //    };
    //}


}
