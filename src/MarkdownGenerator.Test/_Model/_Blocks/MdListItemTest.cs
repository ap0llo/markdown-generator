using System.Linq;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdListItemTest
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MdListItem_can_be_initialized_with_string_content_01(bool useFactoryMethods)
        {
            var listItem = useFactoryMethods
                ? FactoryMethods.ListItem("Content")
                : new MdListItem("Content");

            Assert.Single(listItem.Blocks);
            Assert.IsType<MdParagraph>(listItem.Blocks.Single());

            var paragraph = (MdParagraph)listItem.Blocks.Single();
            Assert.IsType<MdTextSpan>(paragraph.Text);

            var textSpan = (MdTextSpan)paragraph.Text;
            Assert.Equal("Content", textSpan.Text);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MdListItem_can_be_initialized_with_string_content_02(bool useFactoryMethods)
        {
            var listItem = useFactoryMethods
                ? FactoryMethods.ListItem("Content1", "Content2")
                : new MdListItem("Content1", "Content2");

            Assert.Single(listItem.Blocks);
            Assert.IsType<MdParagraph>(listItem.Blocks.Single());

            var paragraph = (MdParagraph)listItem.Blocks.Single();
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
