using Grynwald.MarkdownGenerator.Model;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
{
    public class MdSpanTest
    {
        [Theory]
        [InlineData("Some string")]
        [InlineData("")]
        [InlineData(null)]
        public void String_can_be_implicitly_converted_to_MdSpan(string str)
        {
            MdSpan span = str;

            if (str == null)
            {
                Assert.Null(span);
            }
            else
            {
                Assert.IsType<MdTextSpan>(span);
                Assert.Equal(str, (span as MdTextSpan).Text);
            }
        }
    }
}
