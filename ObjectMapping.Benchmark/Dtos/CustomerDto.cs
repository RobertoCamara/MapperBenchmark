using ObjectMapping.Benchmark.Entities;

namespace ObjectMapping.Benchmark.Dtos;

public record CustomerDto
{
    public Guid Id { get; init; }
    public string? FullName { get; init; }
    public string? Email { get; init; }
    public DateTime? BirthDate { get; init; }

    public static explicit operator Customer(CustomerDto dto)
    {
        return new Customer
        {
            Id = dto.Id,
            FullName = dto.FullName,
            Email = dto.Email,
            BirthDate = dto.BirthDate
        };
    }

    public static explicit operator CustomerDto(Customer entity)
    {
        return new CustomerDto
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Email = entity.Email,
            BirthDate = entity.BirthDate
        };
    }
}