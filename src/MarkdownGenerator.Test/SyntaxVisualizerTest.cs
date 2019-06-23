﻿using Grynwald.MarkdownGenerator.Internal;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
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
                " └─MdParagraph\r\n" +
                "    └─MdCompositeSpan\r\n" +
                "       ├─MdTextSpan\r\n" +
                "       └─MdTextSpan\r\n",
                new MdContainerBlock(
                    new MdParagraph(
                        new MdTextSpan("Text"), ""))
            );

        [Fact]
        public void GetSyntaxTree_returns_expected_result_03() =>
            AssertSyntaxTreeEquals(
                "MdContainerBlock\r\n" +
                " ├─MdParagraph\r\n" +
                " │  └─MdCompositeSpan\r\n" +
                " └─MdParagraph\r\n" +
                "    └─MdCompositeSpan\r\n",
                new MdContainerBlock(new MdParagraph(), new MdParagraph())
            );

        [Fact]
        public void GetSyntaxTree_returns_expected_result_04() =>
            AssertSyntaxTreeEquals(
                "MdBulletList\r\n" +
                " ├─MdListItem\r\n" +
                " │  └─MdParagraph\r\n" +
                " │     └─MdCompositeSpan\r\n" +
                " └─MdListItem\r\n",
                new MdBulletList(new MdListItem(new MdParagraph()), new MdListItem())
            );

        [Fact]
        public void GetSyntaxTree_returns_expected_result_05() =>
            AssertSyntaxTreeEquals(
                "MdOrderedList\r\n" +
                " ├─MdListItem\r\n" +
                " │  └─MdParagraph\r\n" +
                " │     └─MdCompositeSpan\r\n" +
                " └─MdListItem\r\n",
                new MdOrderedList(new MdListItem(new MdParagraph()), new MdListItem())
            );


        [Fact]
        public void GetSyntaxTree_returns_expected_result_06() =>
            AssertSyntaxTreeEquals(
                "MdTable\r\n" +
                " ├─MdTableRow\r\n" +
                " └─MdTableRow\r\n",
                new MdTable(new MdTableRow(), new MdTableRow())
            );


        [Fact]
        public void GetSyntaxTree_returns_expected_result_07() =>
            AssertSyntaxTreeEquals(
                "MdBlockQuote\r\n" +
                " ├─MdParagraph\r\n" +
                " │  └─MdCompositeSpan\r\n" +
                " └─MdParagraph\r\n" +
                "    └─MdCompositeSpan\r\n",
                new MdBlockQuote(new MdParagraph(), new MdParagraph())
            );


        [Fact]
        public void GetSyntaxTree_returns_expected_result_08() =>
            AssertSyntaxTreeEquals(
                "MdParagraph\r\n" +
                " └─MdCompositeSpan\r\n" +
                "    └─MdEmphasisSpan\r\n" +
                "       └─MdTextSpan\r\n",
                new MdParagraph(new MdEmphasisSpan("Text"))
            );


        [Fact]
        public void GetSyntaxTree_returns_expected_result_09() =>
            AssertSyntaxTreeEquals(
                "MdParagraph\r\n" +
                " └─MdCompositeSpan\r\n" +
                "    └─MdStrongEmphasisSpan\r\n" +
                "       └─MdTextSpan\r\n",
                new MdParagraph(new MdStrongEmphasisSpan("Text"))
            );

        [Fact]
        public void GetSyntaxTree_returns_expected_result_10() =>
            AssertSyntaxTreeEquals(
                "MdParagraph\r\n" +
                " └─MdCompositeSpan\r\n" +
                "    └─MdCodeSpan\r\n",
                new MdParagraph(new MdCodeSpan(""))
            );

        [Fact]
        public void GetSyntaxTree_returns_expected_result_11() =>
            AssertSyntaxTreeEquals(
                "MdParagraph\r\n" +
                " └─MdCompositeSpan\r\n" +
                "    └─MdLinkSpan\r\n",
                new MdParagraph(new MdLinkSpan("My Link", "http://example.com"))
            );


        [Fact]
        public void GetSyntaxTree_returns_expected_result_12() =>
            AssertSyntaxTreeEquals(
                "MdParagraph\r\n" +
                " └─MdCompositeSpan\r\n" +
                "    └─MdImageSpan\r\n",
                new MdParagraph(new MdImageSpan("My Link", "http://example.com"))
            );


        [Fact]
        public void GetSyntaxTree_returns_expected_result_13() =>
            AssertSyntaxTreeEquals(
                "MdParagraph\r\n" +
                " └─MdCompositeSpan\r\n" +
                "    └─MdSingleLineSpan\r\n" +
                "       └─MdTextSpan\r\n",
                new MdParagraph(new MdSingleLineSpan("Text"))
            );


        [Fact]
        public void GetSyntaxTree_returns_expected_result_14() =>
            AssertSyntaxTreeEquals(
                "MdParagraph\r\n" +
                " └─MdCompositeSpan\r\n" + 
                "    └─MdRawMarkdownSpan\r\n",
                new MdParagraph(new MdRawMarkdownSpan(""))
            );

        [Fact]
        public void GetSyntaxTree_returns_expected_result_15() =>
            AssertSyntaxTreeEquals(
                "MdContainerBlock\r\n" +
                " └─MdThematicBreak\r\n",
                new MdContainerBlock(new MdThematicBreak())
            );


        [Fact]
        public void GetSyntaxTree_returns_expected_result_16() =>
            AssertSyntaxTreeEquals(
                "MdDocument\r\n" +
                " └─MdContainerBlock\r\n" +
                "    └─MdThematicBreak\r\n",
                new MdDocument(new MdContainerBlock(new MdThematicBreak()))
            );


        private void AssertSyntaxTreeEquals(string expected, MdBlock block)
        {
            var actual = SyntaxVisualizer.GetSyntaxTree(block);
            Assert.Equal(expected, actual);
        }

        private void AssertSyntaxTreeEquals(string expected, MdDocument document)
        {
            var actual = SyntaxVisualizer.GetSyntaxTree(document);
            Assert.Equal(expected, actual);
        }
    }
}
