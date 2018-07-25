using Grynwald.MarkdownGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
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

            Assert.IsType<MdTextSpan>(singleLineSpan1.Content);
            Assert.IsType<MdTextSpan>(singleLineSpan2.Content);

            Assert.Equal("Content1", (singleLineSpan1.Content as MdTextSpan).Text);
            Assert.Equal("Content2", (singleLineSpan2.Content as MdTextSpan).Text);
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

            Assert.IsType<MdTextSpan>(singleLineSpan1.Content);
            Assert.IsType<MdTextSpan>(singleLineSpan2.Content);

            Assert.Equal("Content1", (singleLineSpan1.Content as MdTextSpan).Text);
            Assert.Equal("Content2", (singleLineSpan2.Content as MdTextSpan).Text);
        }
    }    
}
