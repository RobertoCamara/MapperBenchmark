using ObjectMapping.Benchmark.Entities;

namespace ObjectMapping.Benchmark.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public static explicit operator User(UserDto dto) =>
        new()
        {
            Id = dto.Id,
            FullName = dto.FullName,
            Email = dto.Email
        };
}