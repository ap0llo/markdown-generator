using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdHeadingTest
    {
        [Fact]
        public void MdHeading_can_be_initialized_with_string_content_01()
        {
            var heading = new MdHeading("Content", 1);

            Assert.IsType<MdTextSpan>(heading.Text.Content);

            var textSpan = (MdTextSpan)heading.Text.Content;
            Assert.Equal("Content", textSpan.Text);
        }

        [Fact]
        public void MdHeading_can_be_initialized_with_string_content_02()
        {
            var heading = new MdHeading(1, "Content");

            Assert.IsType<MdTextSpan>(heading.Text.Content);

            var textSpan = (MdTextSpan)heading.Text.Content;
            Assert.Equal("Content", textSpan.Text);
        }

        [Fact]
        public void MdHeading_can_be_initialized_with_string_content_03()
        {
            var heading = new MdHeading(1, "Content1", "Content2");

            Assert.IsType<MdCompositeSpan>(heading.Text.Content);
            var compositeSpan = (MdCompositeSpan)heading.Text.Content;

            Assert.IsType<MdTextSpan>(compositeSpan.Spans[0]);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[1]);

            var textSpan1 = (MdTextSpan)compositeSpan.Spans[0];
            var textSpan2 = (MdTextSpan)compositeSpan.Spans[1];
            Assert.Equal("Content1", textSpan1.Text);
            Assert.Equal("Content2", textSpan2.Text);
        }


        [Fact]
        public void MdHeading_can_be_initialized_with_span_content()
        {
            var text = new MdTextSpan("Content");

            var heading = new MdHeading(text, 1);

            Assert.Same(text, heading.Text.Content);
        }

        [Theory]
        [InlineData("   ", "")]
        [InlineData(" heading", "heading")]
        [InlineData("heading123", "heading123")]
        [InlineData("Heading", "heading")]
        [InlineData("My Heading", "my-heading")]
        [InlineData("My Heading with a [link]()", "my-heading-with-a-link")]
        public void Anchor_is_initlaized_with_auto_generated_value(string headingText, string expectedAnchor)
        {
            // ARRANGE
            var heading = new MdHeading(1, new MdRawMarkdownSpan(headingText));

            // ACT / ASSERT
            Assert.Equal(expectedAnchor, heading.Anchor);            
        }


        [Theory, CombinatorialData]
        public void DeepEquals_returns_expected_value(
            [CombinatorialValues(1,2,3,4,5,6)]int level,
            [CombinatorialValues("Heading", "", "some text")] string text)
        {
            var instance1 = new MdHeading(level, text);
            var instance2 = new MdHeading(level, text);
            var instance3 = new MdHeading(level, "SomeOtherText");

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdParagraph()));
        }

        [Fact]
        public void Anchor_can_be_set()
        {
            // ARRANGE
            var heading = new MdHeading(1, "My Heading");

            // ACT
            heading.Anchor = "custom-anchor";

            // ASSERT
            Assert.Equal("custom-anchor", heading.Anchor);
        }
    }
}
