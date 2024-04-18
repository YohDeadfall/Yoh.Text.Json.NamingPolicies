The package provides a set of naming policies for the system JSON serializer in .NET which are missed or incorrectly implemented.

The snake and kebab policies from that package are a part of `System.Text.Json` since the moment when [this pull request](https://github.com/dotnet/runtime/pull/69613) was merged, but since [reworkin policies in .NET](https://github.com/dotnet/runtime/pull/90316) to match JSON.NET there are some behavior differences between `System.Text.Json` and this package. Choose one depending on your priorities:

* `Yoh.Text.Json.NamingPolicies` suits better for communications with services from other ecosystems;
* `System.Text.Json` for compatibility with JSON.NET based services.

# Camel Case

Rewrites an input string changing the case of each word by lower casing the first and capitalizing the rest. All non letter or digin charactwrs are ignored.

```csharp
namespace Yoh.Text.Json.NamingPolicies;

public static class JsonNamingPolicies
{
    public static JsonNamingPolicy CamelCase { get; }
}
```

| Input                | Output              |
|----------------------|---------------------|
| `XMLHttpRequest`     | `xmlHttpRequest`
| `camelCase`          | `camelCase`
| `camelCase`          | `camelCase`
| `snake_case`         | `snakeCase`
| `sNAKE_CASE`         | `snakeCase`
| `kebab-case`         | `kebabCase`
| `kEBAB-CASE`         | `kebabCase`
| `double  space`      | `doubleSpace`
| `double__underscore` | `doubleUnderscore`
| `abc`                | `abc`
| `abC`                | `abC`
| `aBc`                | `aBc`
| `aBC`                | `aBc`
| `aBc`                | `aBc`
| `aBC`                | `abc`
| `abc123def456`       | `abc123def456`
| `abc123Def456`       | `abc123Def456`
| `abc123DEF456`       | `abc123Def456`
| `aBC123DEF456`       | `abc123def456`
| `aBC123def456`       | `abc123def456`
| `abc123def456`       | `abc123def456`
| `  ABC`              | `abc`
| `aBC  `              | `abc`
| `  ABC  `            | `abc`
| `  ABC def  `        | `abcDef`

# Pascal Case

Rewrites an input string capitalizing each word. All non letter or digin charactwrs are ignored.

```csharp
namespace Yoh.Text.Json.NamingPolicies;

public static class JsonNamingPolicies
{
    public static JsonNamingPolicy PascalCase { get; }
}
```

| Input                | Output              |
|----------------------|---------------------|
| `XMLHttpRequest`     | `XmlHttpRequest`
| `camelCase`          | `CamelCase`
| `camelCase`          | `CamelCase`
| `snake_case`         | `SnakeCase`
| `sNAKE_CASE`         | `SnakeCase`
| `kebab-case`         | `KebabCase`
| `kEBAB-CASE`         | `KebabCase`
| `double  space`      | `DoubleSpace`
| `double__underscore` | `DoubleUnderscore`
| `abc`                | `Abc`
| `abC`                | `AbC`
| `aBc`                | `ABc`
| `aBC`                | `ABc`
| `aBc`                | `ABc`
| `aBC`                | `Abc`
| `abc123def456`       | `Abc123def456`
| `abc123Def456`       | `Abc123Def456`
| `abc123DEF456`       | `Abc123Def456`
| `aBC123DEF456`       | `Abc123def456`
| `aBC123def456`       | `Abc123def456`
| `abc123def456`       | `Abc123def456`
| `  ABC`              | `Abc`
| `aBC  `              | `Abc`
| `  ABC  `            | `Abc`
| `  ABC def  `        | `AbcDef`

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