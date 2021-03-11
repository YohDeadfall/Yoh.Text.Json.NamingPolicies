using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace Yoh.Text.Json.NamingPolicies.Benchmarks
{
    public class Benchmarks
    {
        [Params("XMLHttpRequest")]
        public string Name { get; set; }

        [Benchmark]
        public string SnakeLowerCase() =>
            JsonNamingPolicies.SnakeLowerCase.ConvertName(Name);

        [Benchmark]
        public string SnakeUpperCase() =>
            JsonNamingPolicies.SnakeUpperCase.ConvertName(Name);

        [Benchmark]
        public string KebabLowerCase() =>
            JsonNamingPolicies.KebabLowerCase.ConvertName(Name);

        [Benchmark]
        public string KebabUpperCase() =>
            JsonNamingPolicies.KebabUpperCase.ConvertName(Name);
    }
}
