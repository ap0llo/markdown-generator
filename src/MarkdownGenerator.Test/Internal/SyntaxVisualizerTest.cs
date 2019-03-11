using System;
using System.Collections.Generic;
using System.Text;
using Grynwald.MarkdownGenerator.Internal;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Internal
{
    public class SyntaxVisualizerTest
    {
        [Fact]
        public void GetSyntaxTree_returns_expected_result_01() =>
            AssertSyntaxTreeEquals(
                "MdContainerBlock\r\n",
                new MdContainerBlock()
            );

        [Fact]
        public void GetSyntaxTree_returns_expected_result_02() =>
            AssertSyntaxTreeEquals(
                "MdContainerBlock\r\n" +
                "  MdParagraph\r\n",
                new MdContainerBlock(new MdParagraph())
            );

        [Fact]
        public void GetSyntaxTree_returns_expected_result_03() =>
            AssertSyntaxTreeEquals(
                "MdContainerBlock\r\n" +
                "  MdParagraph\r\n" +
                "  MdParagraph\r\n",
                new MdContainerBlock(new MdParagraph(), new MdParagraph())
            );

        [Fact]
        public void GetSyntaxTree_returns_expected_result_04() =>
            AssertSyntaxTreeEquals(
                "MdBulletList\r\n" +
                "  MdListItem\r\n" +
                "    MdParagraph\r\n" +
                "  MdListItem\r\n",
                new MdBulletList(new MdListItem(new MdParagraph()), new MdListItem())
            );

        [Fact]
        public void GetSyntaxTree_returns_expected_result_05() =>
            AssertSyntaxTreeEquals(
                "MdOrderedList\r\n" +
                "  MdListItem\r\n" +
                "    MdParagraph\r\n" +
                "  MdListItem\r\n",
                new MdOrderedList(new MdListItem(new MdParagraph()), new MdListItem())
            );


        [Fact]
        public void GetSyntaxTree_returns_expected_result_06() =>
            AssertSyntaxTreeEquals(
                "MdTable\r\n" +
                "  MdTableRow\r\n" +
                "  MdTableRow\r\n",
                new MdTable(new MdTableRow(), new MdTableRow())
            );


        [Fact]
        public void GetSyntaxTree_returns_expected_result_07() =>
            AssertSyntaxTreeEquals(
                "MdBlockQuote\r\n" +
                "  MdParagraph\r\n" +
                "  MdParagraph\r\n",
                new MdBlockQuote(new MdParagraph(), new MdParagraph())
            );


        private void AssertSyntaxTreeEquals(string expected, MdBlock block)
        {
            var actual = SyntaxVisualizer.GetSyntaxTree(block);
            Assert.Equal(expected, actual);
        }
    }
}
