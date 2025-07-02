using ObjectMapping.Benchmark.Entities;

namespace ObjectMapping.Benchmark.Dtos;

public record AddressDto
{
    public string Street { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string ZipCode { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;

    public static explicit operator Address(AddressDto dto)
    {
        return new Address
        {
            Street = dto.Street,
            City = dto.City,
            State = dto.State,
            ZipCode = dto.ZipCode
        };
    }

    public static explicit operator AddressDto(Address entity)
    {
        return new AddressDto
        {
            Street = entity.Street,
            City = entity.City,
            State = entity.State,
            ZipCode = entity.ZipCode
        };
    }
}