using ObjectMapping.Benchmark.Dtos;

namespace ObjectMapping.Benchmark.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public static explicit operator UserDto(User user) =>
        new()
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email
        };

    public static explicit operator Test(User user) =>
       new()
       {
           Id = user.Id
       };
}

public class Test
{
    public int Id { get; set; }
}