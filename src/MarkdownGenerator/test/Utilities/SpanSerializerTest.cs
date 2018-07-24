using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Grynwald.MarkdownGenerator.Model;
using Grynwald.MarkdownGenerator.Utilities;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Utilities
{
    public class SpanSerializerTest
    {
        [Fact]
        public void RawTextSpan_is_serialized_unchanged()
        {
            var value = "Some markdown, perhaps with a [Link](http://example.com)";
            var span = new MdRawTextSpan(value);

            AssertToStringEquals(value, span);
        }

        [Theory]
        [InlineData("http://example.com/")] // absolute uri
        [InlineData("./other_file.md")]     // relative path
        [InlineData("xref:some_topic")]     // DocFX cross-reference
        public void LinkSpan_is_serialized_as_expected(string link)
        {
            var text = "Link Title";
            var expectedValue = $"[{text}]({link})";

            var span = new MdLinkSpan(text, link);

            AssertToStringEquals(expectedValue, span);
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void Link_text_is_escaped(char charToEscape)
        {
            var title = $"prefix{charToEscape}suffix";
            var link = "file.md";
            var span = new MdLinkSpan(title, link);

            var expectedValue = $"[prefix\\{charToEscape}suffix]({link})";

            AssertToStringEquals(expectedValue, span);
        }

        [Theory]
        [InlineData("http://example.com/image.jpg")] // absolute uri
        [InlineData("./image.png")]                  // relative path
        public void ImageSpan_is_serialized_as_expected(string link)
        {
            var description = "Description";
            var expectedValue = $"![{description}]({link})";

            var span = new MdImageSpan(description, link);

            AssertToStringEquals(expectedValue, span);
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void Image_description_text_is_escaped(char charToEscape)
        {
            var description = $"prefix{charToEscape}suffix";
            var link = "file.png";
            var span = new MdImageSpan(description, link);

            var expectedValue = $"![prefix\\{charToEscape}suffix]({link})";

            AssertToStringEquals(expectedValue, span);
        }

        [Fact]
        public void EmphasisSpan_is_serialized_as_expected()
        {
            var text = "Some text";
            var span = new MdEmphasisSpan(text);

            AssertToStringEquals($"*{text}*", span);
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void Emphasis_text_is_escaped(char charToEscape)
        {
            var text = $"prefix{charToEscape}suffix";            
            var span = new MdEmphasisSpan(text);

            var expectedValue = $"*prefix\\{charToEscape}suffix*";

            AssertToStringEquals(expectedValue, span);
        }

        [Fact]
        public void StrongEmphasisSpan_is_serialized_as_expected()
        {
            var text = "Some text";
            var span = new MdStrongEmphasisSpan(text);

            AssertToStringEquals($"**{text}**", span);
        }


        [Theory]
        [MarkdownSpecialCharacterData]
        public void StrongEmphasis_text_is_escaped(char charToEscape)
        {
            var text = $"prefix{charToEscape}suffix";
            var span = new MdStrongEmphasisSpan(text);

            var expectedValue = $"**prefix\\{charToEscape}suffix**";

            AssertToStringEquals(expectedValue, span);
        }

        [Fact]
        public void CompositeSpan_is_serialized_as_expected()
        {
            var value1 = "Some markdown, perhaps with a [Link](http://example.com). ";
            var value2 = "Some more markdown";

            var span = new MdCompositeSpan(
                new MdRawTextSpan(value1),
                new MdRawTextSpan(value2));

            AssertToStringEquals(value1 + value2, span);
        }


        [Fact]
        public void TextSpan_is_serailaized_as_expected()
        {
            var text = "Text without special characters";
            var span = new MdTextSpan(text);

            AssertToStringEquals(text, span);
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void Characters_in_TextSpan_are_escaped(char character)
        {
            AssertToStringEquals(
                $"prefix\\{character}suffix", 
                new MdTextSpan($"prefix{character}suffix")
            );
        }

        private void AssertToStringEquals(string expected, MdSpan span)
        {
            using (var writer = new StringWriter())
            {
                var serializer = new SpanSerializer(writer);
                serializer.Serialize(span);

                var actual = writer.ToString();
                Assert.Equal(expected, actual);
            }
        }

    }
}
