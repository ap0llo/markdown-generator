using System.Linq;
using Grynwald.MarkdownGenerator.Model;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
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
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[0]);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[1]);

            Assert.Equal("Content1", (compositeSpan.Spans[0] as MdTextSpan).Text);
            Assert.Equal("Content2", (compositeSpan.Spans[1] as MdTextSpan).Text);
        }

    }
}
