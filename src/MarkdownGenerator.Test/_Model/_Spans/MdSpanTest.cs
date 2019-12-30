using Xunit;

namespace Grynwald.MarkdownGenerator.Test
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
                var textSpan = Assert.IsType<MdTextSpan>(span);
                Assert.Equal(str, textSpan.Text);
            }
        }
    }
}
