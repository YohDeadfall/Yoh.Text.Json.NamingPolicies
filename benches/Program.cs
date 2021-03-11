using BenchmarkDotNet.Running;

namespace Yoh.Text.Json.NamingPolicies.Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args) =>
            BenchmarkRunner.Run<Benchmarks>();
    }
}