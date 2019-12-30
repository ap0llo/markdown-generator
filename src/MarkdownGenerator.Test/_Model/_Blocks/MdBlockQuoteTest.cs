using System.Linq;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdBlockQuoteTest
    {
        [Fact]
        public void MdBlockQuote_can_be_initialized_with_string_content_01()
        {
            var block = new MdBlockQuote("Content");

            Assert.Single(block.Blocks);
            Assert.IsType<MdParagraph>(block.Blocks.Single());

            var paragraph = (MdParagraph)block.Blocks.Single();
            Assert.IsType<MdTextSpan>(paragraph.Text);

            var textSpan = (MdTextSpan)paragraph.Text;
            Assert.Equal("Content", textSpan.Text);
        }

        [Fact]
        public void MdBlockQuote_can_be_initialized_with_string_content_02()
        {
            var block = new MdBlockQuote("Content1", "Content2");

            Assert.Single(block.Blocks);
            Assert.IsType<MdParagraph>(block.Blocks.Single());

            var paragraph = (MdParagraph)block.Blocks.Single();
            Assert.IsType<MdCompositeSpan>(paragraph.Text);

            var compositeSpan = (MdCompositeSpan)paragraph.Text;

            Assert.Equal(2, compositeSpan.Spans.Count);
            var textSpan1 = Assert.IsType<MdTextSpan>(compositeSpan.Spans[0]);
            var textSpan2 = Assert.IsType<MdTextSpan>(compositeSpan.Spans[1]);

            Assert.Equal("Content1", textSpan1.Text);
            Assert.Equal("Content2", textSpan2.Text);
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
