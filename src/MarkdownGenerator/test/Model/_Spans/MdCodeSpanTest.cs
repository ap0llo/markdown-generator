using Grynwald.MarkdownGenerator.Model;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
{
    public class MdCodeSpanTest
    {
        [Fact]
        public void ToString_returns_the_expected_value()
        {
            var text = "Code span content";
            var span = new MdCodeSpan(text);

            Assert.Equal($"`{text}`", span.ToString());
        }

        [Fact]
        public void ToString_returns_an_empty_string_if_value_is_empty()
        {
            Assert.Equal(string.Empty, new MdCodeSpan("").ToString());
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void ToString_does_NOT_escape_code_span_content(char charToEscape)
        {
            var text = $"prefix{charToEscape}suffix";
            var span = new MdCodeSpan(text);

            var expectedValue = $"`prefix{charToEscape}suffix`";

            Assert.Equal(expectedValue, span.ToString());
        }
    }
}
