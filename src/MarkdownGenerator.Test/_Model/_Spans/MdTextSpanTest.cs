using System;
using Moq;
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
        [MarkdownSpecialCharacterData]
        public void ToString_uses_the_text_formatter_set_in_the_serialization_options_for_escaping(char character)
        {
            var value = Guid.NewGuid().ToString();

            var formatterMock = new Mock<ITextFormatter>();
            // return some placeholder data to ensure text is are passed through the formatter
            formatterMock.Setup(x => x.EscapeText(It.IsAny<string>())).Returns(value);

            var serializationOptions = new MdSerializationOptions { TextFormatter = formatterMock.Object };

            Assert.Equal(
                value,
                new MdTextSpan($"prefix{character}suffix").ToString(serializationOptions)
            );
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void ToString_uses_the_default_text_formatter_if_formatter_from_serialization_options_is_null(char character)
        {
            var serializationOptions = new MdSerializationOptions { TextFormatter = null };

            Assert.Equal(
                $"prefix\\{character}suffix",
                new MdTextSpan($"prefix{character}suffix").ToString(serializationOptions)
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

        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdTextSpan("content");
            var instance2 = new MdTextSpan("content");
            var instance3 = new MdTextSpan("other content");

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdCodeSpan("")));
        }
    }
}
