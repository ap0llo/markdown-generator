using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MkDocsTextFormatterTest
    {
        [Theory]
        [InlineData("<", "&lt;")]
        [InlineData(">", "&gt;")]
        [InlineData("/", "\\/")]
        [InlineData("\\", "\\\\")]
        [InlineData("*", "\\*")]
        [InlineData("_", "\\_")]
        [InlineData("-", "\\-")]
        [InlineData("=", "\\=")]
        [InlineData("#", "\\#")]
        [InlineData("`", "\\`")]
        [InlineData("~", "\\~")]
        [InlineData("[", "\\[")]
        [InlineData("]", "\\]")]
        [InlineData("!", "\\!")]
        [InlineData("|", "\\|")]
        public void Escape_text_escapes_expected_characters(string input, string expected)
        {
            // ARRANGE
            var sut = MkDocsTextFormatter.Instance;

            // ACT
            var actual = sut.EscapeText(input);

            // ASSERT
            Assert.Equal(expected, actual);
        }
    }
}
