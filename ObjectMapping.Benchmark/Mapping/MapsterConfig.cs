using Mapster;
using ObjectMapping.Benchmark.Dtos;
using ObjectMapping.Benchmark.Entities;

namespace ObjectMapping.Benchmark.Mapping;

public static class MapsterConfig
{
    public static void Register()
    {
        TypeAdapterConfig<User, UserDto>.NewConfig();
        TypeAdapterConfig<UserDto, User>.NewConfig();

        TypeAdapterConfig<Order, OrderDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Customer, src => src.Customer)
            .Map(dest => dest.ShippingAddress, src => src.ShippingAddress)
            .Map(dest => dest.Items, src => src.Items)
            .Map(dest => dest.TotalAmount, src => src.TotalAmount);

        TypeAdapterConfig<OrderDto, Order>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Customer, src => src.Customer)
            .Map(dest => dest.ShippingAddress, src => src.ShippingAddress)
            .Map(dest => dest.Items, src => src.Items)
            .Map(dest => dest.TotalAmount, src => src.TotalAmount);

        TypeAdapterConfig<Customer, CustomerDto>.NewConfig();
        TypeAdapterConfig<CustomerDto, Customer>.NewConfig();

        TypeAdapterConfig<Address, AddressDto>.NewConfig();
        TypeAdapterConfig<AddressDto, Address>.NewConfig();

        TypeAdapterConfig<OrderItem, OrderItemDto>.NewConfig();
        TypeAdapterConfig<OrderItemDto, OrderItem>.NewConfig();
    }
}