using Xunit;

namespace Yoh.Text.Json.NamingPolicies.Tests
{
    public class JsonNamingPoliciesTests
    {
        [Theory]
        [InlineData("XMLHttpRequest", "xml_http_request")]
        public void SnakeLowerCase(string input, string output) =>
            Assert.Equal(output, JsonNamingPolicies.SnakeLowerCase.ConvertName(input));

        [Theory]
        [InlineData("XMLHttpRequest", "XML_HTTP_REQUEST")]
        public void SnakeUpperCase(string input, string output) =>
            Assert.Equal(output, JsonNamingPolicies.SnakeUpperCase.ConvertName(input));

        [Theory]
        [InlineData("XMLHttpRequest", "xml-http-request")]
        public void KebabLowerCase(string input, string output) =>
            Assert.Equal(output, JsonNamingPolicies.KebabLowerCase.ConvertName(input));

        [Theory]
        [InlineData("XMLHttpRequest", "XML-HTTP-REQUEST")]
        public void KebabUpperCase(string input, string output) =>
            Assert.Equal(output, JsonNamingPolicies.KebabUpperCase.ConvertName(input));
    }
}
