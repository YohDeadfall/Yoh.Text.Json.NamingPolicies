The package provides a set of missed naming policies for the system JSON serializer in .NET.

Now the policies from that package are a part of `System.Text.Json` since [a pull request](https://github.com/dotnet/runtime/pull/69613) was merged. The code is identical as well except styling. 

# Snake Case

Rewrites an input string changing the case of each word and connecting them using underscores. All non letter or digit characters are ignored.

```csharp
namespace Yoh.Text.Json.NamingPolicies;

public static class JsonNamingPolicies
{
    public static JsonNamingPolicy SnakeLowerCase { get; }
    public static JsonNamingPolicy SnakeUpperCase { get; }
}
```

| Input                | Output (lower case) | Output (upper case) |
|----------------------|---------------------|---------------------|
| `XMLHttpRequest`     | `xml_http_request`  | `XML_HTTP_REQUEST`
| `camelCase`          | `camel_case`        | `CAMEL_CASE`
| `CamelCase`          | `camel_case`        | `CAMEL_CASE`
| `snake_case`         | `snake_case`        | `SNAKE_CASE`
| `SNAKE_CASE`         | `snake_case`        | `SNAKE_CASE`
| `kebab-case`         | `kebab_case`        | `KEBAB_CASE`
| `KEBAB-CASE`         | `kebab_case`        | `KEBAB_CASE`
| `double  space`      | `double_space`      | `DOUBLE_SPACE`
| `double__underscore` | `double_underscore` | `DOUBLE_UNDERSCORE`
| `abc`                | `abc`               | `ABC`
| `abC`                | `ab_c`              | `AB_C`
| `aBc`                | `a_bc`              | `A_BC`
| `aBC`                | `a_bc`              | `A_BC`
| `ABc`                | `a_bc`              | `A_BC`
| `ABC`                | `abc`               | `ABC`
| `abc123def456`       | `abc123def456`      | `ABC123DEF456`
| `abc123Def456`       | `abc123_def456`     | `ABC123_DEF456`
| `abc123DEF456`       | `abc123_def456`     | `ABC123_DEF456`
| `ABC123DEF456`       | `abc123def456`      | `ABC123DEF456`
| `ABC123def456`       | `abc123def456`      | `ABC123DEF456`
| `Abc123def456`       | `abc123def456`      | `ABC123DEF456`
| `  abc`              | `abc`               | `ABC`
| `abc  `              | `abc`               | `ABC`
| `  abc  `            | `abc`               | `ABC`
| `  abc def  `        | `abc_def`           | `ABC_DEF`

# Kebab Case

Rewrites an input string changing the case of each word and connecting them using hyphens. All non letter or digit characters are ignored.

```csharp
namespace Yoh.Text.Json.NamingPolicies;

public static class JsonNamingPolicies
{
    public static JsonNamingPolicy KebabLowerCase { get; }
    public static JsonNamingPolicy KebabUpperCase { get; }
}
```

| Input                | Output (lower case) | Output (upper case) |
|----------------------|---------------------|---------------------|
| `XMLHttpRequest`     | `xml-http-request`  | `XML-HTTP-REQUEST`
| `camelCase`          | `camel-case`        | `CAMEL-CASE`
| `CamelCase`          | `camel-case`        | `CAMEL-CASE`
| `snake_case`         | `snake-case`        | `SNAKE-CASE`
| `SNAKE_CASE`         | `snake-case`        | `SNAKE-CASE`
| `kebab-case`         | `kebab-case`        | `KEBAB-CASE`
| `KEBAB-CASE`         | `kebab-case`        | `KEBAB-CASE`
| `double  space`      | `double-space`      | `DOUBLE-SPACE`
| `double__underscore` | `double-underscore` | `DOUBLE-UNDERSCORE`
| `abc`                | `abc`               | `ABC`
| `abC`                | `ab-c`              | `AB-C`
| `aBc`                | `a-bc`              | `A-BC`
| `aBC`                | `a-bc`              | `A-BC`
| `ABc`                | `a-bc`              | `A-BC`
| `ABC`                | `abc`               | `ABC`
| `abc123def456`       | `abc123def456`      | `ABC123DEF456`
| `abc123Def456`       | `abc123-def456`     | `ABC123-DEF456`
| `abc123DEF456`       | `abc123-def456`     | `ABC123-DEF456`
| `ABC123DEF456`       | `abc123def456`      | `ABC123DEF456`
| `ABC123def456`       | `abc123def456`      | `ABC123DEF456`
| `Abc123def456`       | `abc123def456`      | `ABC123DEF456`
| `  abc`              | `abc`               | `ABC`
| `abc  `              | `abc`               | `ABC`
| `  abc  `            | `abc`               | `ABC`
| `  abc def  `        | `abc-def`           | `ABC-DEF`