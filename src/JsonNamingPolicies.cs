using System.Text.Json;

namespace Yoh.Text.Json.NamingPolicies
{
    public static class JsonNamingPolicies
    {
        private static JsonSnakeCaseLowerNamingPolicy? _snakeCaseLower;
        private static JsonSnakeCaseUpperNamingPolicy? _snakeCaseUpper;
        private static JsonKebabCaseLowerNamingPolicy? _kebabCaseLower;
        private static JsonKebabCaseUpperNamingPolicy? _kebabCaseUpper;
        private static JsonCamelCaseNamingPolicy? _camelCase;

        public static JsonNamingPolicy SnakeCaseLower => _snakeCaseLower ??= new JsonSnakeCaseLowerNamingPolicy();

        public static JsonNamingPolicy SnakeCaseUpper => _snakeCaseUpper ??= new JsonSnakeCaseUpperNamingPolicy();

        public static JsonNamingPolicy KebabCaseLower => _kebabCaseLower ??= new JsonKebabCaseLowerNamingPolicy();

        public static JsonNamingPolicy KebabCaseUpper => _kebabCaseUpper ??= new JsonKebabCaseUpperNamingPolicy();

        public static JsonNamingPolicy CamelCase => _camelCase ??= new JsonCamelCaseNamingPolicy();
    }
}
