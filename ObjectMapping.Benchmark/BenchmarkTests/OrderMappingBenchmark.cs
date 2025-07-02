using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Bogus;
using Mapster;
using ObjectMapping.Benchmark.Dtos;
using ObjectMapping.Benchmark.Entities;
using System.Runtime.CompilerServices;

namespace ObjectMapping.Benchmark.BenchmarkTests;

[MemoryDiagnoser]
[GcServer(true)]
[SimpleJob(RuntimeMoniker.Net80, launchCount: 1, warmupCount: 5, iterationCount: 15)]
public class OrderMappingBenchmark
{
    private List<Order> _orders = [];
    private List<OrderDto> _orderDtos = [];

    //[Params(10, 1000, 10000)]
    [Params(100)]
    public int Quantity;

    [GlobalSetup]
    public void Setup()
    {
        var customerFaker = new Faker<Customer>("pt_BR")
            .RuleFor(c => c.Id, Guid.NewGuid())
            .RuleFor(c => c.FullName, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.Email());

        var addressFaker = new Faker<Address>("pt_BR")
            .RuleFor(a => a.Street, f => f.Address.StreetName())
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.State, f => f.Address.StateAbbr())
            .RuleFor(a => a.ZipCode, f => f.Address.ZipCode());

        var itemFaker = new Faker<OrderItem>("pt_BR")
            .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
            .RuleFor(i => i.Quantity, f => f.Random.Int(1, 5))
            .RuleFor(i => i.UnitPrice, f => f.Random.Decimal(10, 200));

        var orderFaker = new Faker<Order>("pt_BR")
            .RuleFor(o => o.Id, f => f.IndexFaker + 1)
            .RuleFor(o => o.CreatedAt, f => f.Date.Recent())
            .RuleFor(o => o.Status, f => f.PickRandom<OrderStatus>())
            .RuleFor(o => o.Customer, f => customerFaker.Generate())
            .RuleFor(o => o.ShippingAddress, f => addressFaker.Generate())
            .RuleFor(o => o.Items, f => itemFaker.Generate(f.Random.Int(1, 5)))
            .RuleFor(o => o.TotalAmount, (f, o) => o.Items.Sum(i => i.Quantity * i.UnitPrice));

        _orders = orderFaker.Generate(Quantity);


        var customerDtoFaker = new Faker<CustomerDto>("pt_BR")
            .RuleFor(c => c.Id, Guid.NewGuid())
            .RuleFor(c => c.FullName, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.Email());

        var addressDtoFaker = new Faker<AddressDto>("pt_BR")
            .RuleFor(a => a.Street, f => f.Address.StreetName())
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.State, f => f.Address.StateAbbr())
            .RuleFor(a => a.ZipCode, f => f.Address.ZipCode());

        var itemDtoFaker = new Faker<OrderItemDto>("pt_BR")
            .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
            .RuleFor(i => i.Quantity, f => f.Random.Int(1, 5))
            .RuleFor(i => i.UnitPrice, f => f.Random.Decimal(10, 200));

        var orderDtoFaker = new Faker<OrderDto>("pt_BR")
            .RuleFor(o => o.Id, f => f.IndexFaker + 1)
            .RuleFor(o => o.CreatedAt, f => f.Date.Recent())
            .RuleFor(o => o.Status, f => f.PickRandom<OrderStatus>())
            .RuleFor(o => o.Customer, f => customerDtoFaker.Generate())
            .RuleFor(o => o.ShippingAddress, f => addressDtoFaker.Generate())
            .RuleFor(o => o.Items, f => itemDtoFaker.Generate(f.Random.Int(1, 5)))
            .RuleFor(o => o.TotalAmount, (f, o) => o.Items.Sum(i => i.Quantity * i.UnitPrice));

        _orderDtos = orderDtoFaker.Generate(Quantity);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public List<OrderDto> OperatorMappingToDto()
        => _orders.Select(o => (OrderDto)o).ToList();

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public List<Order> OperatorMappingToEntity()
        => _orderDtos.Select(dto => (Order)dto).ToList();

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public List<OrderDto> MapsterToDto()
        => _orders.Adapt<List<OrderDto>>();

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public List<Order> MapsterToEntity()
        => _orderDtos.Adapt<List<Order>>();
}
