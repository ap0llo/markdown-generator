using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdParagraphTest
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MdParagraph_can_be_initialized_with_string_content_01(bool useFactoryMethods)
        {
            var paragraph = useFactoryMethods 
                ? FactoryMethods.Paragraph("Content")
                : new MdParagraph("Content");

            Assert.IsType<MdTextSpan>(paragraph.Text);

            var textSpan = (MdTextSpan)paragraph.Text;
            Assert.Equal("Content", textSpan.Text);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MdParagraph_can_be_initialized_with_string_content_02(bool useFactoryMethods)
        {
            var paragraph = useFactoryMethods
                ? FactoryMethods.Paragraph("Content1", "Content2")
                : new MdParagraph("Content1", "Content2");

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
