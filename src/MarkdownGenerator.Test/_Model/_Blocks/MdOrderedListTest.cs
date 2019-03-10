using Xunit;

namespace Grynwald.MarkdownGenerator.Test._Model._Blocks
{
    public class MdOrderedListTest
    {
        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdOrderedList(new MdListItem());
            var instance2 = new MdOrderedList(new MdListItem());
            var instance3 = new MdOrderedList(new MdListItem(new MdTextSpan("Text")));

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdParagraph()));
        }
    }
}
