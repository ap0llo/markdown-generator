using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MkDocsTextFormatterTest
    {
        [Theory]
        [InlineData("<", "&lt;")]
        [InlineData(">", "&gt;")]
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



        [Theory]
        [InlineData("/")] // slashes must not escaped for MkDocs / Python Markdown
        public void Escape_does_not_escape_non_escapable_characters(string input)
        {// ARRANGE
            var sut = MkDocsTextFormatter.Instance;

            // ACT
            var escaped = sut.EscapeText(input);

            // ASSERT
            Assert.Equal(input, escaped);
        }

    }
}
