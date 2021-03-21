using System;
using System.Buffers;
using System.Globalization;
using System.Text.Json;
using Yoh.Text.Segmentation;

namespace Yoh.Text.Json.NamingPolicies
{
    internal sealed class JsonSimpleNamingPolicy : JsonNamingPolicy
    {
        private readonly bool _lowercase;
        private readonly char _boundary;

        internal JsonSimpleNamingPolicy(bool lowercase, char boundary) =>
            (_lowercase, _boundary) = (lowercase, boundary);

        public override string ConvertName(string name)
        {
            var words = name.EnumerateWords();
            if (words.MoveNext())
            {
                var bufferLength = name.Length * 2;
                var buffer = bufferLength > 512
                    ? ArrayPool<char>.Shared.Rent(bufferLength)
                    : null;

                var resultLength = 0;
                Span<char> result = buffer is null
                    ? stackalloc char[512]
                    : buffer;

                void WriteWord(ref Span<char> result, ReadOnlySpan<char> word)
                {
                    var required = result.IsEmpty
                        ? word.Length
                        : word.Length + 1;

                    if (required >= result.Length)
                    {
                        var bufferLength = result.Length * 2;
                        var bufferNew = ArrayPool<char>.Shared.Rent(bufferLength);

                        result.CopyTo(bufferNew);

                        if (buffer is not null)
                            ArrayPool<char>.Shared.Return(buffer);

                        buffer = bufferNew;
                    }

                    if (resultLength != 0)
                    {
                        result[resultLength] = _boundary;
                        resultLength += 1;
                    }

                    var destination = result[resultLength..];
                    if (_lowercase)
                    {
                        word.ToLowerInvariant(destination);
                    }
                    else
                    {
                        word.ToUpperInvariant(destination);
                    }

                    resultLength += word.Length;
                }

                do
                {
                    var chars = words.Current;
                    var previousCategory = CharCategory.Boundary;
                    for (int first = 0, index = 0; index < chars.Length; index++)
                    {
                        var current = chars[index];
                        if (current == '_')
                        {
                            if (first == index)
                                first = index + 1;
                            continue;
                        }

                        if (index + 1 == chars.Length)
                        {
                            WriteWord(ref result, chars[first..]);
                        }
                        else
                        {
                            var next = chars[index + 1];
                            var currentCategory = char.GetUnicodeCategory(current) switch
                            {
                                UnicodeCategory.LowercaseLetter => CharCategory.Lowercase,
                                UnicodeCategory.UppercaseLetter => CharCategory.Uppercase,
                                _ => previousCategory
                            };

                            if (currentCategory == CharCategory.Lowercase &&
                                char.IsUpper(next) ||
                                next == '_')
                            {
                                WriteWord(ref result, chars[first..(index + 1)]);

                                previousCategory = CharCategory.Boundary;
                                first = index + 1;

                                continue;
                            }

                            if (previousCategory == CharCategory.Uppercase &&
                                char.IsUpper(current) &&
                                char.IsLower(next))
                            {
                                WriteWord(ref result, chars[first..index]);

                                previousCategory = CharCategory.Boundary;
                                first = index;

                                continue;
                            }

                            previousCategory = currentCategory;
                        }
                    }
                }
                while (words.MoveNext());

                name = new string(result[..resultLength]);

                if (buffer is not null)
                    ArrayPool<char>.Shared.Return(buffer);
            }

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
