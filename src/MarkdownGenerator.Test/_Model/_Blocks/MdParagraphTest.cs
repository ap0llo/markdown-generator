using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdParagraphTest
    {
        [Fact]
        public void MdParagraph_can_be_initialized_with_string_content_01()
        {
            var paragraph = new MdParagraph("Content");
            var expected = new MdCompositeSpan(new MdTextSpan("Content"));

            Assert.True(expected.DeepEquals(paragraph.Text));
        }

        [Fact]
        public void MdParagraph_can_be_initialized_with_string_content_02()
        {
            var paragraph = new MdParagraph("Content1", "Content2");

            Assert.IsType<MdCompositeSpan>(paragraph.Text);

            var compositeSpan = (MdCompositeSpan)paragraph.Text;

            Assert.Equal(2, compositeSpan.Spans.Count);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[0]);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[1]);

            Assert.Equal("Content1", (compositeSpan.Spans[0] as MdTextSpan).Text);
            Assert.Equal("Content2", (compositeSpan.Spans[1] as MdTextSpan).Text);
        }


        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdParagraph("Some Text");
            var instance2 = new MdParagraph("Some Text");
            var instance3 = new MdParagraph("Other", "text");

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdParagraph()));
        }


        [Fact]
        public void Text_property_is_converted_to_CompositeSpan_when_required_01()
        {
            var paragraph = new MdParagraph("Text");

            var expected = new MdCompositeSpan(new MdTextSpan("Text"));
            Assert.True(expected.DeepEquals(paragraph.Text));
        }

        [Fact]
        public void Text_property_is_converted_to_CompositeSpan_when_required_02()
        {
            var paragraph = new MdParagraph("Text", "Text");

            var expected = new MdCompositeSpan(new MdTextSpan("Text"), new MdTextSpan("Text"));
            Assert.True(expected.DeepEquals(paragraph.Text));
        }

        [Fact]
        public void Text_property_is_converted_to_CompositeSpan_when_required_03()
        {
            var paragraph = new MdParagraph();

            var expected = new MdCompositeSpan();
            Assert.True(expected.DeepEquals(paragraph.Text));
        }

        [Fact]
        public void Text_property_is_converted_to_CompositeSpan_when_required_04()
        {
            var paragraph = new MdParagraph();
            paragraph.Add("Text");

            var expected = new MdCompositeSpan(new MdTextSpan("Text"));
            Assert.True(expected.DeepEquals(paragraph.Text));
        }

        [Fact]
        public void Text_property_is_converted_to_CompositeSpan_when_required_05()
        {
            var paragraph = new MdParagraph();
            paragraph.Add("Text");
            paragraph.Add("Text");

            var expected = new MdCompositeSpan(new MdTextSpan("Text"), new MdTextSpan("Text"));
            Assert.True(expected.DeepEquals(paragraph.Text));
        }
    }
}
