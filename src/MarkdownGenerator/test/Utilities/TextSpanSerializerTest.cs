using Grynwald.MarkdownGenerator.Model;
using Grynwald.MarkdownGenerator.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Utilities
{
    public class TextSpanSerializerTest
    {

        [Fact]
        public void RawTextSpan_is_serialized_unchanged()
        {
            var value = "Some markdown, perhaps with a [Link](http://example.com)";
            var span = new MdRawTextSpan(value);

            AssertToStringEquals(value, span);
        }

        [Fact]
        public void CompositeTextSpan_is_serialized_unchanged()
        {
            var value1 = "Some markdown, perhaps with a [Link](http://example.com). ";
            var value2 = "Some more markdown";

            var span = new MdCompositeTextSpan(
                new MdRawTextSpan(value1),
                new MdRawTextSpan(value2));

            AssertToStringEquals(value1 + value2, span);
        }


        private void AssertToStringEquals(string expected, MdTextSpan span)
        {
            using (var writer = new StringWriter())
            {
                var serializer = new TextSpanSerializer(writer);
                serializer.Serialize(span);

                var actual = writer.ToString();
                Assert.Equal(expected, actual);
            }
        }

    }
}
