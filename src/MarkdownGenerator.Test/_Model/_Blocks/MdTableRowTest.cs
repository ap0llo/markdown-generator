using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdTableRowTest
    {
        [Theory]
        [InlineData("NotEscaped", "NotEscaped")]
        [InlineData("Cell|Value", @"Cell\|Value")]
        [InlineData("|CellValue", @"\|CellValue")]
        [InlineData("CellValue|", @"CellValue\|")]
        public void Cell_contents_are_escaped(string rawValue, string expectedValue)
        {
            var row = new MdTableRow(rawValue);
            Assert.Equal(expectedValue, row.Cells.Single().ToString());
        }

        [Theory]
        [InlineData("Cell \r\nValue", "Cell Value")]
        [InlineData("NoLineBreak", "NoLineBreak")]
        [InlineData("Cell\nValue", "Cell Value")]
        [InlineData("Cell\rValue", "Cell Value")]
        [InlineData("Cell\r\nValue", "Cell Value")]
        [InlineData("CellValue\n", "CellValue")]
        [InlineData("CellValue\r", "CellValue")]
        [InlineData("CellValue\r\n", "CellValue")]
        [InlineData("Cell\r\n Value", "Cell Value")]
        [InlineData("Cell \r\n Value", "Cell Value")]
        [InlineData("Cell \rValue", "Cell Value")]
        [InlineData("Cell\r Value", "Cell Value")]
        [InlineData("Cell \r Value", "Cell Value")]
        [InlineData("Cell \nValue", "Cell Value")]
        [InlineData("Cell\n Value", "Cell Value")]
        [InlineData("Cell \n Value", "Cell Value")]
        public void Line_breaks_are_removed_from_cells(string rawValue, string expectedValue)
        {
            var row = new MdTableRow(rawValue);
            Assert.Equal(expectedValue, row.Cells.Single().ToString());
        }

        [Fact]
        public void MdTableRow_can_be_initialized_with_string_content_01()
        {
            var row = new MdTableRow("Content");

            Assert.Single(row.Cells);

            Assert.IsType<MdSingleLineSpan>(row.Cells.Single());
            var singleLineSpan = (MdSingleLineSpan)row.Cells.Single();

            Assert.IsType<MdTextSpan>(singleLineSpan.Content);
            var textSpan = (MdTextSpan)singleLineSpan.Content;
            Assert.Equal("Content", textSpan.Text);
        }

        [Fact]
        public void MdTableRow_can_be_initialized_with_string_content_02()
        {
            var row = new MdTableRow("Content1", "Content2");

            Assert.Equal(2, row.ColumnCount);
            Assert.IsType<MdSingleLineSpan>(row[0]);
            Assert.IsType<MdSingleLineSpan>(row[1]);

            var singleLineSpan1 = (MdSingleLineSpan)row[0];
            var singleLineSpan2 = (MdSingleLineSpan)row[1];

            var textSpan1 = Assert.IsType<MdTextSpan>(singleLineSpan1.Content);
            var textSpan2 = Assert.IsType<MdTextSpan>(singleLineSpan2.Content);

            Assert.Equal("Content1", textSpan1.Text);
            Assert.Equal("Content2", textSpan2.Text);
        }

        [Fact]
        public void MdTableRow_can_be_initialized_with_string_content_03()
        {
            var cells = (IEnumerable<string>)new[] { "Content1", "Content2" };

            var row = new MdTableRow(cells);

            Assert.Equal(2, row.ColumnCount);
            Assert.IsType<MdSingleLineSpan>(row[0]);
            Assert.IsType<MdSingleLineSpan>(row[1]);

            var singleLineSpan1 = (MdSingleLineSpan)row[0];
            var singleLineSpan2 = (MdSingleLineSpan)row[1];

            var textSpan1 = Assert.IsType<MdTextSpan>(singleLineSpan1.Content);
            var textSpan2 = Assert.IsType<MdTextSpan>(singleLineSpan2.Content);

            Assert.Equal("Content1", textSpan1.Text);
            Assert.Equal("Content2", textSpan2.Text);
        }

        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdTableRow("Some Text");
            var instance2 = new MdTableRow("Some Text");
            var instance3 = new MdTableRow("Other", "text");

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
        }

        [Fact]
        public void Cells_are_wrapped_in_an_instance_of_MdSingleLineSpan_when_necessary()
        {
            var row = new MdTableRow(new MdTextSpan("Cell 1"));
            row.Add("Cell 2");

            Assert.All(row.Cells, cell => Assert.IsType<MdSingleLineSpan>(cell));
        }

        [Fact]
        public void Cells_are_not_wrapped_in_an_instance_of_MdSingleLineSpan_if_span_already_is_a_SingleLineSPan()
        {
            var cell1 = new MdSingleLineSpan(new MdTextSpan("Cell 1"));
            var cell2 = new MdSingleLineSpan(new MdTextSpan("Cell 2"));

            var row = new MdTableRow(cell1);
            row.Add(cell2);

            Assert.All(row.Cells, cell => Assert.True(ReferenceEquals(cell, cell1) || ReferenceEquals(cell, cell2)));
        }
    }
}
