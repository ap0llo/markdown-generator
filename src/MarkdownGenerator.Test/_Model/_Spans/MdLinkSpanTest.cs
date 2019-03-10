using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdLinkSpanTest
    {
        [Theory]
        [InlineData("http://example.com/")] // absolute uri
        [InlineData("./other_file.md")]     // relative path
        [InlineData("xref:some_topic")]     // DocFX cross-reference
        public void ToString_returns_the_expected_value(string link)
        {
            var text = "Link Title";
            var expectedValue = $"[{text}]({link})";

            var span = new MdLinkSpan(text, link);

            Assert.Equal(expectedValue, span.ToString());
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void ToString_escapes_special_characters_in_link_text(char charToEscape)
        {
            var title = $"prefix{charToEscape}suffix";
            var link = "file.md";
            var span = new MdLinkSpan(title, link);

            var expectedValue = $"[prefix\\{charToEscape}suffix]({link})";

            Assert.Equal(expectedValue, span.ToString());
        }

        [Fact]
        public void ToString_returns_an_empty_string_if_both_text_and_uri_are_empty()
        {
            Assert.Equal(string.Empty, new MdLinkSpan("", "").ToString());
        }


        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdLinkSpan("content", "http://uri");
            var instance2 = new MdLinkSpan("content", "http://uri");
            var instance3 = new MdLinkSpan("other content", "http://uri");
            var instance4 = new MdLinkSpan("other content", "http://uri2");

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdTextSpan("")));
            Assert.False(instance3.DeepEquals(instance4));
        }
    }
}
