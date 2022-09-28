using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Yoh.Text.Json.NamingPolicies.Benchmarks
{
    public class Benchmarks
    {
        public static void Main(string[] args) =>
            BenchmarkRunner.Run<Benchmarks>();

        [Params("XMLHttpRequest")]
        public string Name { get; set; } = string.Empty;

        [Benchmark]
        public string SnakeLowerCase() =>
            JsonNamingPolicies.SnakeCaseLower.ConvertName(Name);

        [Benchmark]
        public string SnakeUpperCase() =>
            JsonNamingPolicies.SnakeCaseUpper.ConvertName(Name);

        [Benchmark]
        public string KebabLowerCase() =>
            JsonNamingPolicies.KebabCaseLower.ConvertName(Name);

        [Benchmark]
        public string KebabUpperCase() =>
            JsonNamingPolicies.KebabCaseUpper.ConvertName(Name);
    }
}
