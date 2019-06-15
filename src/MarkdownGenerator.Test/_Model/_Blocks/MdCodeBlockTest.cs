using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdCodeBlockTest
    {
        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdCodeBlock("content");
            var instance2 = new MdCodeBlock("content");
            var instance3 = new MdCodeBlock("other content");
            var instance4 = new MdCodeBlock("other content", "infoString");
            var instance5 = new MdCodeBlock("other content", "infoString");
            var instance6 = new MdCodeBlock("other content", "otherInfoString");

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));
            Assert.True(instance4.DeepEquals(instance5));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdParagraph()));
            Assert.False(instance1.DeepEquals(instance6));
            Assert.False(instance4.DeepEquals(instance6));
        }
    }
}
