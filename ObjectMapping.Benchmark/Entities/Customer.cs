namespace ObjectMapping.Benchmark.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }
}
