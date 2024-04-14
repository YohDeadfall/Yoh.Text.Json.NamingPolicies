using System.Text.Json;

namespace Yoh.Text.Json.NamingPolicies;

public static class JsonNamingPolicies
{
    private static JsonCamelCaseNamingPolicy? _camelCase;
    private static JsonPascalCaseNamingPolicy? _pascalCase;
    private static JsonSnakeCaseLowerNamingPolicy? _snakeCaseLower;
    private static JsonSnakeCaseUpperNamingPolicy? _snakeCaseUpper;
    private static JsonKebabCaseLowerNamingPolicy? _kebabCaseLower;
    private static JsonKebabCaseUpperNamingPolicy? _kebabCaseUpper;

    public static JsonNamingPolicy CamelCase => _camelCase ??= new JsonCamelCaseNamingPolicy();

    public static JsonNamingPolicy PascalCase => _pascalCase ??= new JsonPascalCaseNamingPolicy();

    public static JsonNamingPolicy SnakeCaseLower => _snakeCaseLower ??= new JsonSnakeCaseLowerNamingPolicy();

    public static JsonNamingPolicy SnakeCaseUpper => _snakeCaseUpper ??= new JsonSnakeCaseUpperNamingPolicy();

    public static JsonNamingPolicy KebabCaseLower => _kebabCaseLower ??= new JsonKebabCaseLowerNamingPolicy();

    public static JsonNamingPolicy KebabCaseUpper => _kebabCaseUpper ??= new JsonKebabCaseUpperNamingPolicy();
}
