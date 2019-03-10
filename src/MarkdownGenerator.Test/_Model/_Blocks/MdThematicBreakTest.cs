using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdThematicBreakTest
    {
        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdThematicBreak();

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(new MdThematicBreak()));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(new MdParagraph()));
        }
    }
}
