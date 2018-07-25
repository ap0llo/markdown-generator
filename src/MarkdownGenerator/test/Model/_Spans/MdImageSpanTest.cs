using Grynwald.MarkdownGenerator.Model;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
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
    }
}
