namespace Yoh.Text.Json.NamingPolicies
{
    internal sealed class JsonSnakeCaseLowerNamingPolicy : JsonSeparatorNamingPolicy
    {
        public JsonSnakeCaseLowerNamingPolicy()
            : base(lowercase: true, separator: '_')
        {
        }
    }
}
