namespace Yoh.Text.Json.NamingPolicies;

internal sealed class JsonKebabCaseUpperNamingPolicy : JsonSeparatorNamingPolicy
{
    public JsonKebabCaseUpperNamingPolicy()
        : base(lowercase: false, separator: '-')
    {
    }
}
