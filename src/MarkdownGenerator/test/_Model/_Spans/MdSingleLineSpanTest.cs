using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdSingleLineSpanTest
    {
        [Theory]
        [InlineData("Line1 \r\nLine2", "Line1 Line2")]
        [InlineData("NoLineBreak", "NoLineBreak")]
        [InlineData("Line1\nLine2", "Line1 Line2")]
        [InlineData("Line1\rLine2", "Line1 Line2")]
        [InlineData("Line1\r\nLine2", "Line1 Line2")]
        [InlineData("Line1Line2\n", "Line1Line2")]
        [InlineData("Line1Line2\r", "Line1Line2")]
        [InlineData("Line1Line2\r\n", "Line1Line2")]
        [InlineData("Line1\r\n Line2", "Line1 Line2")]
        [InlineData("Line1 \r\n Line2", "Line1 Line2")]
        [InlineData("Line1 \rLine2", "Line1 Line2")]
        [InlineData("Line1\r Line2", "Line1 Line2")]
        [InlineData("Line1 \r Line2", "Line1 Line2")]
        [InlineData("Line1 \nLine2", "Line1 Line2")]
        [InlineData("Line1\n Line2", "Line1 Line2")]
        [InlineData("Line1 \n Line2", "Line1 Line2")]
        public void ToString_removes_line_breaks_from_the_input(string input, string expected)
        {
            var singleLine = new MdSingleLineSpan(new MdTextSpan(input));
            Assert.Equal(expected, singleLine.ToString());
        }


        [Fact]
        public void ToString_returns_an_empty_string_if_value_is_empty()
        {
            var span = new MdSingleLineSpan(new MdTextSpan(""));
            Assert.Equal(string.Empty, span.ToString());
        }
    }
}
