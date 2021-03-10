using System;
using System.Text.Json;

namespace Yoh.Text.Json.NamingPolicies
{
    public static class JsonNamingPolicies
    {
        private const char SnakeWordBoundary = '_';
        private const char KebabWordBoundary = '-';

        private static JsonNamingPolicy _snakeLowerCase;
        private static JsonNamingPolicy _snakeUpperCase;
        private static JsonNamingPolicy _kebabLowerCase;
        private static JsonNamingPolicy _kebabUpperCase;

        public static JsonNamingPolicy SnakeLowerCase => _snakeLowerCase ??= new JsonSimpleNamingPolicy(lowercase: true, SnakeWordBoundary);

        public static JsonNamingPolicy SnakeUpperCase => _snakeUpperCase ??= new JsonSimpleNamingPolicy(lowercase: false, SnakeWordBoundary);

        public static JsonNamingPolicy KebabLowerCase => _kebabLowerCase ??= new JsonSimpleNamingPolicy(lowercase: true, KebabWordBoundary);

        public static JsonNamingPolicy KebabUpperCase => _kebabUpperCase ??= new JsonSimpleNamingPolicy(lowercase: false, KebabWordBoundary);
    }
}
