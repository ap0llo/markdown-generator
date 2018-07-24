using Grynwald.MarkdownGenerator.Model;
using Grynwald.MarkdownGenerator.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        [InlineData("http://example.com/")] // absolute uri
        [InlineData("./other_file.md")]     // relative path
        public void ImageSpan_is_serialized_as_expected(string link)
        {
            var description = "Description";
            var expectedValue = $"![{description}]({link})";

            var span = new MdImageSpan(description, link);

            AssertToStringEquals(expectedValue, span);
        }

        [Fact]
        public void CompositeSpan_is_serialized_unchanged()
        {
            var value1 = "Some markdown, perhaps with a [Link](http://example.com). ";
            var value2 = "Some more markdown";

            var span = new MdCompositeSpan(
                new MdRawTextSpan(value1),
                new MdRawTextSpan(value2));

            AssertToStringEquals(value1 + value2, span);
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
