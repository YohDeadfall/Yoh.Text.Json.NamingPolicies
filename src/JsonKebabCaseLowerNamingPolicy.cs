namespace Yoh.Text.Json.NamingPolicies
{
    internal sealed class JsonKebabCaseLowerNamingPolicy : JsonSeparatorNamingPolicy
    {
        public JsonKebabCaseLowerNamingPolicy()
            : base(lowercase: true, separator: '-')
        {
        }
    }
}
