using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdTableTest
    {
        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdTable(new MdTableRow(MdEmptySpan.Instance));
            var instance2 = new MdTable(new MdTableRow(MdEmptySpan.Instance));
            var instance3 = new MdTable(new MdTableRow(MdEmptySpan.Instance), new MdTableRow(new MdTextSpan("Text")));

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdParagraph()));
        }
    }
}
