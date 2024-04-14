namespace Yoh.Text.Json.NamingPolicies;

internal sealed class JsonSnakeCaseUpperNamingPolicy : JsonSeparatorNamingPolicy
{
    public JsonSnakeCaseUpperNamingPolicy()
        : base(lowercase: false, separator: '_')
    {
    }
}
