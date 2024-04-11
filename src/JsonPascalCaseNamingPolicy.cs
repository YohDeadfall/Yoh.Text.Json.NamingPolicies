using System;

namespace Yoh.Text.Json.NamingPolicies
{
    internal sealed class JsonPascalCaseNamingPolicy : JsonNamingPolicyBase
    {
        protected override int TryWriteWord(bool first, ReadOnlySpan<char> word, Span<char> destination)
        {
            var written = word.ToLowerInvariant(destination);
            if (written > 0)
            {
                destination[0] = char.ToUpperInvariant(destination[0]);
            }

            return written;
        }
    }
}
