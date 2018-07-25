using Grynwald.MarkdownGenerator.Model;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
{
    public class MdEmphasisSpanTest
    {
        [Fact]
        public void ToString_returns_the_expected_value()
        {
            var text = "Some text";
            var span = new MdEmphasisSpan(text);
            Assert.Equal($"*{text}*", span.ToString());
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void ToString_escapes_special_characters(char charToEscape)
        {
            var text = $"prefix{charToEscape}suffix";
            var span = new MdEmphasisSpan(text);

            var expectedValue = $"*prefix\\{charToEscape}suffix*";

            Assert.Equal(expectedValue, span.ToString());
        }
    }
}
