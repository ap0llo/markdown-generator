using Grynwald.MarkdownGenerator.Model;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
{
    public class MdRawMarkdownSpanTest
    {
        [Fact]
        public void ToString_returns_the_expected_value()
        {
            var value = "Some markdown, perhaps with a [Link](http://example.com)";
            var span = new MdRawMarkdownSpan(value);

            Assert.Equal(value, span.ToString());
        }        
    }
}
