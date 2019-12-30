using System;
using System.Linq;
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


        [Fact]
        public void Insert_inserts_a_row_at_the_specifed_index_01()
        {
            // ARRANGE
            var instance = new MdTable(new MdTableRow(MdEmptySpan.Instance));
            var row = new MdTableRow(MdEmptySpan.Instance);

            // ACT
            instance.Insert(0, row);

            // ASSERT
            Assert.Equal(1, instance.RowCount);
            Assert.Same(row, instance.Rows.Single());
        }

        [Fact]
        public void Insert_inserts_a_row_at_the_specifed_index_02()
        {
            // ARRANGE
            var instance = new MdTable(new MdTableRow(MdEmptySpan.Instance))
            {
                new MdTableRow(MdEmptySpan.Instance)
            };

            var row = new MdTableRow(MdEmptySpan.Instance);

            // ACT
            instance.Insert(1, row);

            // ASSERT
            Assert.Equal(2, instance.RowCount);
            Assert.Same(row, instance.Rows.Last());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Insert_inserts_a_row_at_the_specifed_index_03(int insertAt)
        {
            // ARRANGE
            var instance = new MdTable(new MdTableRow(MdEmptySpan.Instance))
            {
                new MdTableRow(MdEmptySpan.Instance),
                new MdTableRow(MdEmptySpan.Instance)
            };

            var row = new MdTableRow(MdEmptySpan.Instance);

            // ACT
            instance.Insert(insertAt, row);

            // ASSERT
            Assert.Equal(3, instance.RowCount);
            Assert.Same(row, instance.Rows.Skip(insertAt).First());
        }

        [Fact]
        public void Insert_throws_expected_exceptions()
        {
            // ARRANGE
            var instance = new MdTable(new MdTableRow(MdEmptySpan.Instance));

            // ACT / ASSERT
            Assert.Throws<ArgumentNullException>(() => instance.Insert(0, null!));
            Assert.Throws<ArgumentOutOfRangeException>(() => instance.Insert(-1, new MdTableRow(MdEmptySpan.Instance)));
            Assert.Throws<ArgumentOutOfRangeException>(() => instance.Insert(2, new MdTableRow(MdEmptySpan.Instance)));
        }
    }
}
