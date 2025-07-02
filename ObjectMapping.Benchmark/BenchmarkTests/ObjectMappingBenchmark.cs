using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Mapster;
using ObjectMapping.Benchmark.Dtos;
using ObjectMapping.Benchmark.Entities;
using System.Runtime.CompilerServices;

namespace ObjectMapping.Benchmark.BenchmarkTests;

[MemoryDiagnoser(true)]
[GcServer(true)]
[SimpleJob(RuntimeMoniker.Net80, launchCount: 1, warmupCount: 5, iterationCount: 15)]
public class ObjectMappingBenchmark
{
    private User? _user;
    private UserDto? _userDto;

    [GlobalSetup]
    public void Setup()
    {
        _user = new User
        {
            Id = 1,
            FullName = "Um nome qualquer",
            Email = "email@example.com"
        };

        _userDto = new UserDto
        {
            Id = 1,
            FullName = "Um nome qualquer",
            Email = "email@example.com"
        };
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UserDto OperatorMappingToDto()
    {
        return (UserDto)_user;
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public User OperatorMappingToEntity()
    {
        return (User)_userDto;
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UserDto MapsterToDto()
    {
        return _user.Adapt<UserDto>();
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public User MapsterToEntity()
    {
        return _userDto.Adapt<User>();
    }
}