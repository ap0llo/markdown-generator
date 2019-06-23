using System;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdBlockQuoteTest
    {

        [Fact]
        public void Constructor_checks_arguments_for_null()
        {
            Assert.Throws<ArgumentNullException>(() => new MdBlockQuote(null));
            Assert.Throws<ArgumentNullException>(() => new MdBlockQuote((object[])null));
            Assert.Throws<ArgumentNullException>(() => new MdBlockQuote(null, null));
        }

        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdBlockQuote(new MdParagraph());
            var instance2 = new MdBlockQuote(new MdParagraph());
            var instance3 = new MdBlockQuote(new MdParagraph(new MdTextSpan("Text")));

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdParagraph()));
        }
    }
}
