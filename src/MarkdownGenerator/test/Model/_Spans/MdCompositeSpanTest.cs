using Grynwald.MarkdownGenerator.Model;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
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
    }
}
