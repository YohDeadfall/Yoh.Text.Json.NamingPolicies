using System;
using System.Buffers;
using System.Globalization;
using System.Text.Json;

namespace Yoh.Text.Json.NamingPolicies
{
    internal abstract class JsonSeparatorNamingPolicy : JsonNamingPolicyBase
    {
        private readonly bool _lowercase;
        private readonly char _separator;

        internal JsonSeparatorNamingPolicy(bool lowercase, char separator)
        {
            _lowercase = lowercase;
            _separator = separator;
        }

        protected override int TryWriteWord(bool first, ReadOnlySpan<char> word, Span<char> destination)
        {
            var offset = first ? 0 : 1;
            if (offset < destination.Length)
            {
                if (!first)
                {
                    destination[0] = _separator;
                }

                destination = destination.Slice(offset);

                var written = _lowercase
                    ? word.ToLowerInvariant(destination)
                    : word.ToUpperInvariant(destination);

                return written + offset;
            }

            return 0;
        }
    }
}
