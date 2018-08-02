using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdTextSpanTest
    {
        [Fact]
        public void ToString_returns_the_expected_value()
        {
            var text = "Text without special characters";
            var span = new MdTextSpan(text);

            Assert.Equal(text, span.ToString());
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void ToString_escapes_special_characters(char character)
        {
            Assert.Equal(
                $"prefix\\{character}suffix",
                new MdTextSpan($"prefix{character}suffix").ToString()
            );
        }


        [Theory]
        [InlineData("Some string")]
        [InlineData("")]
        [InlineData(null)]
        public void String_can_be_implicitly_converted_to_MdTextSpan(string str)
        {
            MdTextSpan span = str;

            if (str == null)
            {
                Assert.Null(span);
            }
            else
            {
                Assert.Equal(str, span.Text);
            }
        }
    }
}
