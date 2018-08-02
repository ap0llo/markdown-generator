using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdCompositeSpanTest
    {
        [Fact]
        public void ToString_returns_the_expected_value()
        {
            var value1 = "Some markdown, perhaps with a [Link](http://example.com). ";
            var value2 = "Some more markdown";

            var span = new MdCompositeSpan(
                new MdRawMarkdownSpan(value1),
                new MdRawMarkdownSpan(value2));

            Assert.Equal(value1 + value2, span.ToString());
        }

        [Fact]
        public void ToString_returns_an_empty_string_if_value_is_empty()
        {
            var span = new MdCompositeSpan(MdEmptySpan.Instance, new MdTextSpan(""));
            Assert.Equal(string.Empty, span.ToString());
        }
    }
}
