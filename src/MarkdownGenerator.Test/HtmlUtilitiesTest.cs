using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class HtmlUtilitiesTest
    {
        [Theory]
        [InlineData("   ", "")]
        [InlineData(" heading", "heading")]
        [InlineData("heading123", "heading123")]
        [InlineData("Heading", "heading")]
        [InlineData("My Heading", "my-heading")]
        [InlineData("My Heading with a [link]()", "my-heading-with-a-link")]
        public void ToUrlSlug_returns_expected_value(string text, string expected)
        {
            // ARRANGE
            var actual = HtmlUtilities.ToUrlSlug(text);

            // ACT / ASSERT
            Assert.Equal(expected, actual);
        }
    }
}
