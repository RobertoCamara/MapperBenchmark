using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Mapster;
using Bogus;
using System.Runtime.CompilerServices;
using ObjectMapping.Benchmark.Entities;
using ObjectMapping.Benchmark.Dtos;

namespace ObjectMapping.Benchmark.BenchmarkTests;

[MemoryDiagnoser(true)]
[GcServer(true)]
[SimpleJob(RuntimeMoniker.Net80, launchCount: 1, warmupCount: 5, iterationCount: 15)]
public class ObjectMappingListBenchmark
{
    private List<User> _users = [];
    private List<UserDto> _userDtos = [];

    //[Params(10, 1000, 10000)]    
    [Params(100)]
    public int Quantity;

    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker("pt_BR");
        _users = Enumerable.Range(1, Quantity).Select(i => new User
        {
            Id = i,
            FullName = faker.Name.FullName(),
            Email = faker.Internet.Email()
        }).ToList();

        _userDtos = _users.Select(u => (UserDto)u).ToList();
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public List<UserDto> OperatorMappingToDto()
    {
        return _users.Select(user => (UserDto)user).ToList();
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public List<User> OperatorMappingToEntity()
    {
        return _userDtos.Select(dto => (User)dto).ToList();
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public List<UserDto> MapsterToDto()
    {
        return _users.Adapt<List<UserDto>>();
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public List<User> MapsterToEntity()
    {
        return _userDtos.Adapt<List<User>>();
    }
}
