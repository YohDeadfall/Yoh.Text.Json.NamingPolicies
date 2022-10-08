using System;
using System.Buffers;
using System.Globalization;
using System.Text.Json;

namespace Yoh.Text.Json.NamingPolicies
{
    internal abstract class JsonSeparatorNamingPolicy : JsonNamingPolicy
    {
        private readonly bool _lowercase;
        private readonly char _separator;

        internal JsonSeparatorNamingPolicy(bool lowercase, char separator)
        {
            _lowercase = lowercase;
            _separator = separator;
        }

        public override string ConvertName(string name)
        {
            var bufferLength = name.Length * 2;
            var buffer = bufferLength > JsonConstants.StackallocCharThreshold
                ? ArrayPool<char>.Shared.Rent(bufferLength)
                : null;

            var resultLength = 0;
            Span<char> result = buffer is null
                ? stackalloc char[JsonConstants.StackallocCharThreshold]
                : buffer;

            void ExpandBuffer(ref Span<char> result)
            {
                var bufferNew = ArrayPool<char>.Shared.Rent(bufferLength *= 2);

                result.CopyTo(bufferNew);

                if (buffer is not null)
                    ArrayPool<char>.Shared.Return(buffer, clearArray: true);

                buffer = bufferNew;
                result = buffer;
            }

            void WriteWord(ReadOnlySpan<char> word, ref Span<char> result)
            {
                if (word.IsEmpty)
                    return;

                var requiredLength = result.IsEmpty
                    ? word.Length
                    : word.Length + 1;

                if (requiredLength > result.Length)
                    ExpandBuffer(ref result);

                if (resultLength != 0)
                {
                    result[resultLength] = _separator;
                    resultLength += 1;
                }

                var destination = result.Slice(resultLength);

                int written;
                while (true)
                {
                    written = _lowercase
                        ? word.ToLowerInvariant(destination)
                        : word.ToUpperInvariant(destination);

                    if (written > 0)
                        break;

                    ExpandBuffer(ref result);
                }

                resultLength += written;
            }

            int first = 0;
            var chars = name.AsSpan();
            var previousCategory = CharCategory.Boundary;
            for (int index = 0; index < chars.Length; index++)
            {
                var current = chars[index];
                var currentCategoryUnicode = char.GetUnicodeCategory(current);
                if (currentCategoryUnicode == UnicodeCategory.SpaceSeparator ||
                    currentCategoryUnicode >= UnicodeCategory.ConnectorPunctuation &&
                    currentCategoryUnicode <= UnicodeCategory.OtherPunctuation)
                {
                    WriteWord(chars.Slice(first, index - first), ref result);

                    previousCategory = CharCategory.Boundary;
                    first = index + 1;

                    continue;
                }

                if (index + 1 < chars.Length)
                {
                    var next = chars[index + 1];
                    var currentCategory = currentCategoryUnicode switch
                    {
                        UnicodeCategory.LowercaseLetter => CharCategory.Lowercase,
                        UnicodeCategory.UppercaseLetter => CharCategory.Uppercase,
                        _ => previousCategory
                    };

                    if (currentCategory == CharCategory.Lowercase && char.IsUpper(next) ||
                        next == '_')
                    {
                        WriteWord(chars.Slice(first, index - first + 1), ref result);

                        previousCategory = CharCategory.Boundary;
                        first = index + 1;

                        continue;
                    }

                    if (previousCategory == CharCategory.Uppercase &&
                        currentCategoryUnicode == UnicodeCategory.UppercaseLetter &&
                        char.IsLower(next))
                    {
                        WriteWord(chars.Slice(first, index - first), ref result);

                        previousCategory = CharCategory.Boundary;
                        first = index;

                        continue;
                    }

                    previousCategory = currentCategory;
                }
            }

            WriteWord(chars.Slice(first), ref result);

            name = result.Slice(0, resultLength).ToString();

            if (buffer is not null)
                ArrayPool<char>.Shared.Return(buffer, clearArray: true);

            return name;
        }

        private enum CharCategory
        {
            Boundary,
            Lowercase,
            Uppercase,
        }
    }
}
