using BenchmarkDotNet.Running;
using ObjectMapping.Benchmark.Config;
using ObjectMapping.Benchmark.Mapping;

namespace ObjectMapping.Benchmark;

public class Program
{
    public static void Main(string[] args)
    {
        MapsterConfig.Register();

        BenchmarkSwitcher
            .FromAssembly(typeof(Program).Assembly)
            .Run(args, new BenchmarkConfig());
    }
}