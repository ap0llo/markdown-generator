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
            Assert.Equal(expectedValue, row.Cells.Single());
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
            Assert.Equal(expectedValue, row.Cells.Single());
        }
    }
}
