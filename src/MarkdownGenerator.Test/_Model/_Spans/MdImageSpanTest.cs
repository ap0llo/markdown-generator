using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdImageSpanTest
    {
        [Theory]
        [InlineData("http://example.com/image.jpg")] // absolute uri
        [InlineData("./image.png")]                  // relative path
        public void ToString_returns_the_expected_value(string link)
        {
            var description = "Description";
            var expectedValue = $"![{description}]({link})";

            var span = new MdImageSpan(description, link);

            Assert.Equal(expectedValue, span.ToString());
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void ToString_escapes_special_characters_in_image_description(char charToEscape)
        {
            var description = $"prefix{charToEscape}suffix";
            var link = "file.png";
            var span = new MdImageSpan(description, link);

            var expectedValue = $"![prefix\\{charToEscape}suffix]({link})";

            Assert.Equal(expectedValue, span.ToString());
        }

        [Fact]
        public void ToString_returns_an_empty_string_if_both_description_and_uri_are_empty()
        {
            Assert.Equal(string.Empty, new MdImageSpan("", "").ToString());
        }

        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdImageSpan("content", "http://uri");
            var instance2 = new MdImageSpan("content", "http://uri");
            var instance3 = new MdImageSpan("other content", "http://uri");
            var instance4 = new MdImageSpan("other content", "http://uri2");

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdTextSpan("")));
            Assert.False(instance3.DeepEquals(instance4));
        }
    }
}
