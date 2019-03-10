using Xunit;

namespace Grynwald.MarkdownGenerator.Test
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

        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdRawMarkdownSpan("content");
            var instance2 = new MdRawMarkdownSpan("content");
            var instance3 = new MdRawMarkdownSpan("other content");

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdTextSpan("")));
        }
    }
}
