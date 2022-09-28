using System;
using System.Text.Json;

namespace Yoh.Text.Json.NamingPolicies
{
    public static class JsonNamingPolicies
    {
        private const char SnakeWordBoundary = '_';
        private const char KebabWordBoundary = '-';

        private static JsonNamingPolicy? _snakeCaseLower;
        private static JsonNamingPolicy? _snakeCaseUpper;
        private static JsonNamingPolicy? _kebabCaseLower;
        private static JsonNamingPolicy? _kebabCaseUpper;

        public static JsonNamingPolicy SnakeCaseLower => _snakeCaseLower ??= new JsonSimpleNamingPolicy(lowercase: true, SnakeWordBoundary);

        public static JsonNamingPolicy SnakeCaseUpper => _snakeCaseUpper ??= new JsonSimpleNamingPolicy(lowercase: false, SnakeWordBoundary);

        public static JsonNamingPolicy KebabCaseLower => _kebabCaseLower ??= new JsonSimpleNamingPolicy(lowercase: true, KebabWordBoundary);

        public static JsonNamingPolicy KebabCaseUpper => _kebabCaseUpper ??= new JsonSimpleNamingPolicy(lowercase: false, KebabWordBoundary);
    }
}
