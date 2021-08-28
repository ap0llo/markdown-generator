using System;
using System.IO;
using System.Linq;
using Grynwald.MarkdownGenerator.Internal;
using Xunit;
using Xunit.Abstractions;

namespace Grynwald.MarkdownGenerator.Test.Internal
{
    public partial class DocumentSerializerTest
    {
        private readonly ITestOutputHelper m_OutputHelper;

        public DocumentSerializerTest(ITestOutputHelper outputHelper)
        {
            m_OutputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper));
        }


        [Fact]
        public void Headings_are_serialized_as_expected() =>
            AssertToStringEquals(
                "# Heading 1\r\n",
                new MdDocument(new MdHeading("Heading 1", 1))
            );

        [Fact]
        public void Paragraphs_are_serialized_as_expected() =>
            AssertToStringEquals(
                "Paragraph\r\n",
                new MdDocument(new MdParagraph("Paragraph"))
            );

        [Fact]
        public void Multiple_paragraphs_are_serialized_as_expected() =>
            AssertToStringEquals(
                "Paragraph1\r\n" +
                "\r\n" +
                "Paragraph2\r\n",
                new MdDocument(
                    new MdParagraph("Paragraph1"),
                    new MdParagraph("Paragraph2"))
            );

        [Fact]
        public void Multiple_paragraphs_and_headings_are_serialized_as_expected() =>
            AssertToStringEquals(
                "# Heading 1\r\n" +
                "\r\n" +
                "Paragraph1\r\n" +
                "\r\n" +
                "## Heading 2\r\n" +
                "\r\n" +
                "Paragraph2\r\n",
                new MdDocument(
                    new MdHeading("Heading 1", 1),
                    new MdParagraph("Paragraph1"),
                    new MdHeading("Heading 2", 2),
                    new MdParagraph("Paragraph2"))
            );

        [Fact]
        public void Bullet_lists_are_serialized_as_expected() =>
            AssertToStringEquals(
                "- Item 1\r\n" +
                "- Item 2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdListItem("Item 1"),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Ordered_lists_are_serialized_as_expected() =>
            AssertToStringEquals(
                "1. Item 1\r\n" +
                "2. Item 2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdListItem("Item 1"),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Bullet_lists_are_surrounded_by_blank_lines() =>
            AssertToStringEquals(
                "# Heading\r\n" +
                "\r\n" +
                "- Item 1\r\n" +
                "- Item 2\r\n" +
                "\r\n" +
                "Paragraph\r\n",
                new MdDocument(
                    new MdHeading("Heading", 1),
                    new MdBulletList(
                        new MdListItem("Item 1"),
                        new MdListItem("Item 2")
                    ),
                    new MdParagraph("Paragraph"))
            );

        [Fact]
        public void Ordered_lists_are_surrounded_by_blank_lines() =>
            AssertToStringEquals(
                "# Heading\r\n" +
                "\r\n" +
                "1. Item 1\r\n" +
                "2. Item 2\r\n" +
                "\r\n" +
                "Paragraph\r\n",
                new MdDocument(
                    new MdHeading("Heading", 1),
                    new MdOrderedList(
                        new MdListItem("Item 1"),
                        new MdListItem("Item 2")
                    ),
                    new MdParagraph("Paragraph"))
            );

        [Fact]
        public void Multi_level_bullet_lists_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "- Item 1\r\n" +
                "  - Item 1.1\r\n" +
                "  - Item 1.2\r\n" +
                "- Item 2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdListItem(
                            new MdParagraph("Item 1"),
                            new MdBulletList(
                                new MdListItem("Item 1.1"),
                                new MdListItem("Item 1.2"))),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Multi_level_ordered_lists_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "1. Item 1\r\n" +
                "   1. Item 1.1\r\n" +
                "   2. Item 1.2\r\n" +
                "2. Item 2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdListItem(
                            new MdParagraph("Item 1"),
                            new MdOrderedList(
                                new MdListItem("Item 1.1"),
                                new MdListItem("Item 1.2"))),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Multi_bullet_level_lists_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "- Item 1\r\n" +
                "  - Item 1.1\r\n" +
                "    - Item 1.1.1\r\n" +
                "  - Item 1.2\r\n" +
                "- Item 2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdListItem(
                            new MdParagraph("Item 1"),
                            new MdBulletList(
                                new MdListItem(
                                    new MdParagraph("Item 1.1"),
                                    new MdBulletList(
                                        new MdListItem("Item 1.1.1"))),
                                new MdListItem("Item 1.2"))),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Multi_level_ordered_lists_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "1. Item 1\r\n" +
                "   1. Item 1.1\r\n" +
                "      1. Item 1.1.1\r\n" +
                "   2. Item 1.2\r\n" +
                "2. Item 2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdListItem(
                            new MdParagraph("Item 1"),
                            new MdOrderedList(
                                new MdListItem(
                                    new MdParagraph("Item 1.1"),
                                    new MdOrderedList(
                                        new MdListItem("Item 1.1.1"))),
                                new MdListItem("Item 1.2"))),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Ordered_lists_can_contain_bullet_lists() =>
            AssertToStringEquals(
                "1. Item 1\r\n" +
                "   - Item 1.1\r\n" +
                "   - Item 1.2\r\n" +
                "2. Item 2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdListItem(
                            new MdParagraph("Item 1"),
                            new MdBulletList(
                                new MdListItem("Item 1.1"),
                                new MdListItem("Item 1.2"))),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Paragraphs_in_bullet_lists_can_contain_multiple_lines() =>
            AssertToStringEquals(
                "- Item 1 consists of  \r\n" +
                "  multiple lines\r\n" +
                "  - Item 1.1  \r\n" +
                "    as well\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdListItem(
                            new MdParagraph("Item 1 consists of\r\nmultiple lines"),
                            new MdBulletList(
                                new MdListItem(
                                    new MdParagraph("Item 1.1\r\nas well"))
                                ))))
            );

        [Fact]
        public void Paragraphs_in_ordered_lists_can_contain_multiple_lines() =>
            AssertToStringEquals(
                "1. Item 1 consists of  \r\n" +
                "   multiple lines\r\n" +
                "   1. Item 1.1  \r\n" +
                "      as well\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdListItem(
                            new MdParagraph("Item 1 consists of\r\nmultiple lines"),
                            new MdOrderedList(
                                new MdListItem(
                                    new MdParagraph("Item 1.1\r\nas well"))
                                ))))
            );

        [Fact]
        public void Multiple_paragraphs_in_bullet_list_items_are_serialized_correctly() =>
            AssertToStringEquals(
                "- Paragraph 1\r\n" +
                "\r\n" +
                "  Paragraph 2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdListItem(
                            new MdParagraph("Paragraph 1"),
                            new MdParagraph("Paragraph 2"))))
            );

        [Fact]
        public void Multiple_paragraphs_in_ordered_list_items_are_serialized_correctly() =>
            AssertToStringEquals(
                "1. Paragraph 1\r\n" +
                "\r\n" +
                "   Paragraph 2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdListItem(
                            new MdParagraph("Paragraph 1"),
                            new MdParagraph("Paragraph 2"))))
            );

        [Fact]
        public void Line_breaks_in_paragraphs_are_replaced_with_hard_line_breaks() =>
            AssertToStringEquals(
                "Line1  \r\n" +
                "Line2\r\n",
                new MdDocument(new MdParagraph("Line1\r\nLine2"))
            );

        [Fact]
        public void Code_blocks_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "```\r\n" +
                "Line1\r\n" +
                "Line2\r\n" +
                "```\r\n",
                new MdDocument(new MdCodeBlock("Line1\r\nLine2"))
            );

        [Fact]
        public void Code_blocks_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "```xml\r\n" +
                "Line1\r\n" +
                "Line2\r\n" +
                "```\r\n",
                new MdDocument(new MdCodeBlock("Line1\r\nLine2", "xml"))
            );

        [Fact]
        public void Tables_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "| Column1 | Column2 |\r\n" +
                "| ------- | ------- |\r\n" +
                "| Cell1   | Cell2   |\r\n",
                new MdDocument(
                    new MdTable(
                        new MdTableRow("Column1", "Column2"),
                        new MdTableRow("Cell1", "Cell2")))
            );

        [Fact]
        public void Tables_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "| Column1 | Column2 |\r\n" +
                "| ------- | ------- |\r\n" +
                "| Cell1   |         |\r\n" +
                "| Cell3   | Cell4   |\r\n",
                new MdDocument(
                    new MdTable(
                        new MdTableRow("Column1", "Column2"),
                        new MdTableRow("Cell1"),
                        new MdTableRow("Cell3", "Cell4")))
            );

        [Fact]
        public void Tables_are_preceded_by_a_blank_line() =>
            AssertToStringEquals(
                "___\r\n" +
                "\r\n" +
                "| Column1 | Column2 |\r\n" +
                "| ------- | ------- |\r\n" +
                "| Cell1   |         |\r\n" +
                "| Cell3   | Cell4   |\r\n",
                new MdDocument(
                    new MdThematicBreak(),
                    new MdTable(
                        new MdTableRow("Column1", "Column2"),
                        new MdTableRow("Cell1"),
                        new MdTableRow("Cell3", "Cell4"))));

        [Fact]
        public void Tables_are_followed_by_a_blank_line() =>
            AssertToStringEquals(
                "| Column1 | Column2 |\r\n" +
                "| ------- | ------- |\r\n" +
                "| Cell1   |         |\r\n" +
                "| Cell3   | Cell4   |\r\n" +
                "\r\n" +
                "___\r\n",
                new MdDocument(
                    new MdTable(
                        new MdTableRow("Column1", "Column2"),
                        new MdTableRow("Cell1"),
                        new MdTableRow("Cell3", "Cell4")),
                    new MdThematicBreak()));

        [Fact]
        public void Serializer_respects_the_TableStyle_serialization_option()
        {
            var options = new MdSerializationOptions()
            {
                TableStyle = MdTableStyle.Html
            };

            AssertToStringEquals(
                "<table>" + "\r\n" +
                "  <thead>" + "\r\n" +
                "    <tr>" + "\r\n" +
                "      <th>Column1</th>" + "\r\n" +
                "      <th>Column2</th>" + "\r\n" +
                "    </tr>" + "\r\n" +
                "  </thead>" + "\r\n" +
                "  <tbody>" + "\r\n" +
                "    <tr>" + "\r\n" +
                "      <td>Cell1</td>" + "\r\n" +
                "    </tr>" + "\r\n" +
                "    <tr>" + "\r\n" +
                "      <td>Cell3</td>" + "\r\n" +
                "      <td>Cell4</td>" + "\r\n" +
                "    </tr>" + "\r\n" +
                "  </tbody>" + "\r\n" +
                "</table>" + "\r\n",
                new MdDocument(
                    new MdTable(
                        new MdTableRow("Column1", "Column2"),
                        new MdTableRow("Cell1"),
                        new MdTableRow("Cell3", "Cell4"))),
                options
            );
        }

        [Fact]
        public void Table_cell_contents_are_escaped() =>
            AssertToStringEquals(
                "| Column1 |\r\n" +
                "| ------- |\r\n" +
                "| Cel\\|l1 |\r\n",
                new MdDocument(
                    new MdTable(
                        new MdTableRow("Column1"),
                        new MdTableRow("Cel|l1")))
            );

        [Theory]
        [InlineData("\r")]
        [InlineData("\n")]
        [InlineData("\r\n")]
        public void Line_breaks_are_removed_from_table_cells(string lineBreak) =>
            AssertToStringEquals(
                "| Column1     |\r\n" +
                "| ----------- |\r\n" +
                "| Part1 Part2 |\r\n",
                new MdDocument(
                    new MdTable(
                        new MdTableRow("Column1"),
                        new MdTableRow($"Part1{lineBreak}Part2")))
            );

        [Fact]
        public void Bullet_lists_can_contain_tables() =>
            AssertToStringEquals(
                "- ListItem1\r\n" +
                "\r\n" +
                "  | Column1 | Column2 |\r\n" +
                "  | ------- | ------- |\r\n" +
                "  | Cell1   |         |\r\n" +
                "  | Cell3   | Cell4   |\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdListItem(
                            new MdParagraph("ListItem1"),
                            new MdTable(
                                new MdTableRow("Column1", "Column2"),
                                new MdTableRow("Cell1"),
                                new MdTableRow("Cell3", "Cell4"))))));

        [Fact]
        public void Ordered_lists_can_contain_tables() =>
            AssertToStringEquals(
                "1. ListItem1\r\n" +
                "\r\n" +
                "   | Column1 | Column2 |\r\n" +
                "   | ------- | ------- |\r\n" +
                "   | Cell1   |         |\r\n" +
                "   | Cell3   | Cell4   |\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdListItem(
                            new MdParagraph("ListItem1"),
                            new MdTable(
                                new MdTableRow("Column1", "Column2"),
                                new MdTableRow("Cell1"),
                                new MdTableRow("Cell3", "Cell4"))))));

        [Fact]
        public void Ordered_lists_with_more_than_10_items_are_serialized_as_expected() =>
            AssertToStringEquals(
                "1. Item\r\n" +
                "2. Item\r\n" +
                "3. Item\r\n" +
                "4. Item\r\n" +
                "5. Item\r\n" +
                "6. Item\r\n" +
                "7. Item\r\n" +
                "8. Item\r\n" +
                "9. Item\r\n" +
                "10. Item\r\n" +
                "11. Item\r\n",
                new MdDocument(
                    new MdOrderedList(Enumerable.Repeat("Item", 11).Select(x => new MdListItem(x)))
                )
            );

        [Fact]
        public void ThematicBreaks_are_serialized_as_expected() =>
            AssertToStringEquals(
                "Paragraph\r\n" +
                "\r\n" +
                "___\r\n" +
                "\r\n" +
                "Paragraph\r\n",
                new MdDocument(
                    new MdParagraph("Paragraph"),
                    new MdThematicBreak(),
                    new MdParagraph("Paragraph"))
            );

        [Fact]
        public void BlockQuotes_are_serialized_as_expected() =>
            AssertToStringEquals(
                "> Quote\r\n",
                new MdDocument(new MdBlockQuote("Quote"))
            );

        [Fact]
        public void BlockQuotes_can_contain_lists() =>
            AssertToStringEquals(
                "> Quote\r\n" +
                ">\r\n" +
                "> - Item1\r\n" +
                "> - Item2\r\n",
                new MdDocument(
                    new MdBlockQuote(
                        new MdParagraph("Quote"),
                        new MdBulletList(
                            new MdListItem("Item1"),
                            new MdListItem("Item2"))))
            );

        [Fact]
        public void Bullet_lists_can_contain_BlockQuotes() =>
            AssertToStringEquals(
                "- Item1\r\n" +
                "\r\n" +
                "  > Quote1\r\n" +
                "  >\r\n" +
                "  > Quote2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdListItem(
                            new MdParagraph("Item1"),
                            new MdBlockQuote(
                                new MdParagraph("Quote1"),
                                new MdParagraph("Quote2")))))
            );

        [Fact]
        public void Ordered_lists_can_contain_BlockQuotes() =>
            AssertToStringEquals(
                "1. Item1\r\n" +
                "\r\n" +
                "   > Quote1\r\n" +
                "   >\r\n" +
                "   > Quote2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdListItem(
                            new MdParagraph("Item1"),
                            new MdBlockQuote(
                                new MdParagraph("Quote1"),
                                new MdParagraph("Quote2")))))
            );

        [Theory]
        [InlineData(MdEmphasisStyle.Asterisk, '*')]
        [InlineData(MdEmphasisStyle.Underscore, '_')]
        public void Serializer_respects_EmphasisStyle_serialization_option(MdEmphasisStyle emphasisStyle, char emphasisCharater)
        {
            var options = new MdSerializationOptions()
            {
                EmphasisStyle = emphasisStyle
            };

            AssertToStringEquals(
               $"# {emphasisCharater}Heading{emphasisCharater}\r\n",
               new MdDocument(
                   new MdHeading(1, new MdEmphasisSpan("Heading"))),
                options
            );
        }

        [Theory]
        [InlineData(MdThematicBreakStyle.Dash, "---")]
        [InlineData(MdThematicBreakStyle.Asterisk, "***")]
        [InlineData(MdThematicBreakStyle.Underscore, "___")]
        public void Serializer_respects_ThematicBreakStyle_serialization_option(MdThematicBreakStyle style, string expectedBreak)
        {
            var options = new MdSerializationOptions()
            {
                ThematicBreakStyle = style
            };

            AssertToStringEquals(
                $"{expectedBreak}\r\n",
                new MdDocument(new MdThematicBreak()),
                options
            );
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Serializer_respects_HeadingStyle_serialization_option_01(int level)
        {
            var options = new MdSerializationOptions()
            {
                HeadingStyle = MdHeadingStyle.Atx
            };

            AssertToStringEquals(
                $"{new String('#', level)} Heading\r\n",
                new MdDocument(new MdHeading(level, "Heading")),
                options
            );
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Serializer_respects_HeadingStyle_serialization_option_02(int level)
        {
            var options = new MdSerializationOptions()
            {
                HeadingStyle = MdHeadingStyle.Setext
            };

            if (level == 1)
            {
                AssertToStringEquals(
                   $"Heading\r\n" +
                   $"=======\r\n",
                   new MdDocument(new MdHeading(level, "Heading")),
                   options);
            }
            else if (level == 2)
            {
                AssertToStringEquals(
                   $"Heading\r\n" +
                   $"-------\r\n",
                   new MdDocument(new MdHeading(level, "Heading")),
                   options);
            }
            else
            {
                AssertToStringEquals(
                    $"{new String('#', level)} Heading\r\n",
                    new MdDocument(new MdHeading(level, "Heading")),
                    options);
            }
        }

        [Fact]
        public void Serializer_respects_HeadingAnchor_serialization_option_01()
        {
            var options = new MdSerializationOptions()
            {
                HeadingStyle = MdHeadingStyle.Atx,
                HeadingAnchorStyle = MdHeadingAnchorStyle.Tag
            };

            AssertToStringEquals(
                "## <a id=\"heading\"></a> Heading\r\n",
                new MdDocument(new MdHeading(2, "Heading")),
                options
            );
        }

        [Fact]
        public void Serializer_respects_HeadingAnchor_serialization_option_02()
        {
            var options = new MdSerializationOptions()
            {
                HeadingStyle = MdHeadingStyle.Setext,
                HeadingAnchorStyle = MdHeadingAnchorStyle.Tag
            };

            AssertToStringEquals(
                 "<a id=\"heading\"></a>\r\n" +
                 "\r\n" +
                 "Heading\r\n" +
                $"-------\r\n",
                new MdDocument(new MdHeading(2, "Heading")),
                options
            );
        }

        [Fact]
        public void Serializer_respects_HeadingAnchor_serialization_option_03()
        {
            var options = new MdSerializationOptions()
            {
                MaxLineLength = 10,
                HeadingStyle = MdHeadingStyle.Setext,
                HeadingAnchorStyle = MdHeadingAnchorStyle.Tag
            };

            AssertToStringEquals(
                "<a id=\"heading-heading-part-2\"></a>\r\n" +
                "\r\n" +
                "Heading,\r\n" +
                "heading\r\n" +
                "part 2\r\n" +
                "========\r\n",
                new MdDocument(new MdHeading(1, "Heading, heading part 2")),
                options
            );
        }

        [Fact]
        public void Serializer_respects_HeadingAnchor_serialization_option_04()
        {
            // When HeadingAnchorStyle is 'Auto' do not include a tag if the
            // id is the same as the auto generated one

            var options = new MdSerializationOptions()
            {
                HeadingStyle = MdHeadingStyle.Atx,
                HeadingAnchorStyle = MdHeadingAnchorStyle.Auto
            };

            AssertToStringEquals(
                "## Heading\r\n",
                new MdDocument(new MdHeading(2, "Heading")),
                options
            );
        }

        [Fact]
        public void Serializer_respects_HeadingAnchor_serialization_option_05()
        {
            // When HeadingAnchorStyle is 'Auto' include a tag if the
            // id is the different from the auto generated one

            var options = new MdSerializationOptions()
            {
                HeadingStyle = MdHeadingStyle.Atx,
                HeadingAnchorStyle = MdHeadingAnchorStyle.Auto
            };

            AssertToStringEquals(
                "## <a id=\"foo\"></a> Heading\r\n",
                new MdDocument(new MdHeading(2, "Heading") { Anchor = "foo" }),
                options
            );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        public void Serializer_does_not_include_anchor_in_output_is_anchor_is_null_or_whitespace(string anchor)
        {
            var options = new MdSerializationOptions()
            {
                HeadingStyle = MdHeadingStyle.Atx,
                HeadingAnchorStyle = MdHeadingAnchorStyle.Tag
            };

            var heading = new MdHeading(2, "Heading")
            {
                Anchor = anchor
            };

            AssertToStringEquals(
                "## Heading\r\n",
                new MdDocument(heading),
                options
            );
        }

        [Theory]
        [InlineData(MdCodeBlockStyle.Tilde, '~')]
        [InlineData(MdCodeBlockStyle.Backtick, '`')]
        public void Serializer_respects_CodeBlockStyle_serialization_option(MdCodeBlockStyle style, char codeBlockChar)
        {
            var options = new MdSerializationOptions()
            {
                CodeBlockStyle = style
            };

            AssertToStringEquals(
                $"{codeBlockChar}{codeBlockChar}{codeBlockChar}\r\n" +
                $"Some Code\r\n" +
                $"{codeBlockChar}{codeBlockChar}{codeBlockChar}\r\n",
                new MdDocument(new MdCodeBlock("Some Code")),
                options
            );
        }

        [Theory]
        [InlineData(MdBulletListStyle.Dash, '-')]
        [InlineData(MdBulletListStyle.Plus, '+')]
        [InlineData(MdBulletListStyle.Asterisk, '*')]
        public void Serializer_respects_BulletListStyle_serialization_option(MdBulletListStyle style, char listItemCharacter)
        {
            var options = new MdSerializationOptions()
            {
                BulletListStyle = style
            };

            AssertToStringEquals(
                $"{listItemCharacter} Item1\r\n" +
                $"{listItemCharacter} Item2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdListItem("Item1"),
                        new MdListItem("Item2")
                    )
                ),
                options
            );
        }

        [Theory]
        [InlineData(MdOrderedListStyle.Dot)]
        [InlineData(MdOrderedListStyle.Parenthesis)]
        public void Serializer_respects_OrderedListStyle_serialization_option(MdOrderedListStyle style)
        {
            char listItemCharacter;
            switch (style)
            {
                case MdOrderedListStyle.Dot:
                    listItemCharacter = '.';
                    break;
                case MdOrderedListStyle.Parenthesis:
                    listItemCharacter = ')';
                    break;
                default:
                    throw new NotImplementedException();
            }

            var options = new MdSerializationOptions()
            {
                OrderedListStyle = style
            };

            AssertToStringEquals(
                $"1{listItemCharacter} Item1\r\n" +
                $"2{listItemCharacter} Item2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdListItem("Item1"),
                        new MdListItem("Item2")
                )),
                options
            );
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Serializer_respects_MinimumListIndentationWidth_for_ordered_lists(int indentation)
        {
            var options = new MdSerializationOptions()
            {
                MinimumListIndentationWidth = indentation
            };

            // List items are always indented by at least the length of the list marker.
            // In this test, the marker length is 3 for all items, e.g. '1. '

            AssertToStringEquals(
                $"1. Item1\r\n" +
                $"{new String(' ', Math.Max(indentation, 3))}1. Item 1.1\r\n" +
                $"{new String(' ', Math.Max(indentation, 3) * 2)}1. Item 1.1.1\r\n" +
                $"2. Item2\r\n" +
                $"{new String(' ', Math.Max(indentation, 3))}1. Item 2.1\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdListItem(
                            new MdParagraph("Item1"),
                            new MdOrderedList(
                                new MdListItem(
                                    new MdParagraph("Item 1.1"),
                                    new MdOrderedList(
                                        new MdListItem("Item 1.1.1"))))
                        ),
                        new MdListItem(
                            new MdParagraph("Item2"),
                            new MdOrderedList(
                                new MdListItem("Item 2.1"))
                        )
                )),
                options
            );
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Serializer_respects_MinimumListIndentationWidth_for_bullet_lists(int indentation)
        {
            var options = new MdSerializationOptions()
            {
                MinimumListIndentationWidth = indentation
            };

            // List items are always indented by at least the length of the list marker.
            // In this test, the marker length is 2 for all items: '- '

            AssertToStringEquals(
                $"- Item1\r\n" +
                $"{new String(' ', Math.Max(indentation, 2))}- Item 1.1\r\n" +
                $"{new String(' ', Math.Max(indentation, 2) * 2)}- Item 1.1.1\r\n" +
                $"- Item2\r\n" +
                $"{new String(' ', Math.Max(indentation, 2))}- Item 2.1\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdListItem(
                            new MdParagraph("Item1"),
                            new MdBulletList(
                                new MdListItem(
                                    new MdParagraph("Item 1.1"),
                                    new MdBulletList(
                                        new MdListItem("Item 1.1.1"))))
                        ),
                        new MdListItem(
                            new MdParagraph("Item2"),
                            new MdBulletList(
                                new MdListItem("Item 2.1"))
                        )
                )),
                options
            );
        }

        [Theory]
        [InlineData(MdThematicBreakStyle.Underscore, '_', MdBulletListStyle.Asterisk, '*')]
        [InlineData(MdThematicBreakStyle.Underscore, '_', MdBulletListStyle.Dash, '-')]
        [InlineData(MdThematicBreakStyle.Underscore, '_', MdBulletListStyle.Plus, '+')]
        [InlineData(MdThematicBreakStyle.Dash, '-', MdBulletListStyle.Asterisk, '*')]
        [InlineData(MdThematicBreakStyle.Dash, '_', MdBulletListStyle.Dash, '-')]
        [InlineData(MdThematicBreakStyle.Dash, '-', MdBulletListStyle.Plus, '+')]
        [InlineData(MdThematicBreakStyle.Asterisk, '_', MdBulletListStyle.Asterisk, '*')]
        [InlineData(MdThematicBreakStyle.Asterisk, '*', MdBulletListStyle.Dash, '-')]
        [InlineData(MdThematicBreakStyle.Asterisk, '*', MdBulletListStyle.Plus, '+')]
        public void Serializer_changes_ThematicBreak_style_when_inside_bullet_list_with_a_conflicting_style(MdThematicBreakStyle thematicBreakStyle, char thematicBreakCharacter, MdBulletListStyle bulletListStyle, char bulletListCharacter)
        {
            var options = new MdSerializationOptions()
            {
                BulletListStyle = bulletListStyle,
                ThematicBreakStyle = thematicBreakStyle
            };

            AssertToStringEquals(
                $"{bulletListCharacter} Item1\r\n" +
                $"\r\n" +
                $"  {thematicBreakCharacter}{thematicBreakCharacter}{thematicBreakCharacter}\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdListItem(new MdParagraph("Item1"), new MdThematicBreak())
                    )
                ),
                options
            );
        }

        [Fact]
        public void Setext_headings_are_formatted_to_the_maximum_line_length_01()
        {
            var options = new MdSerializationOptions()
            {
                MaxLineLength = 10,
                HeadingStyle = MdHeadingStyle.Setext
            };

            AssertToStringEquals("Heading,\r\n" +
                "heading\r\n" +
                "part 2\r\n" +
                "========\r\n",
                new MdDocument(new MdHeading(1, "Heading, heading part 2")),
                options
            );
        }

        [Fact]
        public void Setext_headings_are_formatted_to_the_maximum_line_length_02()
        {
            var options = new MdSerializationOptions()
            {
                MaxLineLength = 5,
                HeadingStyle = MdHeadingStyle.Setext
            };

            AssertToStringEquals("Heading\r\n" +
                "heading\r\n" +
                "=======\r\n",
                new MdDocument(new MdHeading(1, "Heading  heading")),
                options
            );
        }

        [Fact]
        public void Setext_headings_are_formatted_to_the_maximum_line_length_03()
        {
            var options = new MdSerializationOptions()
            {
                MaxLineLength = 20,
                HeadingStyle = MdHeadingStyle.Setext
            };

            AssertToStringEquals(
                "Heading 1\r\n" +
                "=========\r\n",
                new MdDocument(new MdHeading(1, "Heading 1")),
                options
            );
        }

        [Fact]
        public void Paragraphs_are_formatted_to_the_maximum_line_length_01()
        {
            var options = new MdSerializationOptions()
            {
                MaxLineLength = 5
            };

            AssertToStringEquals(
               "aaaaaaaa\r\n" +
               "bbbb\r\n",
               new MdDocument(
                   new MdParagraph("aaaaaaaa bbbb")
                ),
               options
           );

        }

        [Fact]
        public void Paragraphs_are_formatted_to_the_maximum_line_length_02()
        {
            var options = new MdSerializationOptions()
            {
                MaxLineLength = 5
            };

            AssertToStringEquals(
               "aaaaaaaa\r\n" +
               "bbbb  \r\n" +
               "cccc\r\n",
               new MdDocument(
                   new MdParagraph("aaaaaaaa bbbb\r\ncccc")
                ),
               options
           );
        }

        [Fact]
        public void Paragraphs_in_lists_are_formatted_to_the_maximum_line_length()
        {
            var options = new MdSerializationOptions()
            {
                MaxLineLength = 5
            };

            AssertToStringEquals(
               "- aaaaaaaa\r\n" +
               "  bb\r\n" +
               "  cc\r\n",
               new MdDocument(
                   new MdBulletList(new MdListItem(new MdParagraph("aaaaaaaa bb cc")))
                ),
               options
           );

        }

        [Fact]
        public void Paragraphs_in_block_quotes_are_formatted_to_the_maximum_line_length()
        {
            var options = new MdSerializationOptions()
            {
                MaxLineLength = 5
            };

            AssertToStringEquals(
               "> aaaaaaaa\r\n" +
               "> bb\r\n" +
               "> cc\r\n",
               new MdDocument(
                   new MdBlockQuote(new MdParagraph("aaaaaaaa bb cc"))
                ),
               options
           );
        }

        [Fact]
        public void EmptyBlock_is_seralized_as_expected() =>
            AssertToStringEquals("", new MdDocument(MdEmptyBlock.Instance));


        private void AssertToStringEquals(string expected, MdDocument document, MdSerializationOptions? options = null)
        {
            using (var writer = new StringWriter())
            {
                var serializer = new DocumentSerializer(writer, options);
                serializer.Serialize(document);

                var actual = writer.ToString();

                m_OutputHelper.WriteLine("--------------");
                m_OutputHelper.WriteLine("Expected:");
                m_OutputHelper.WriteLine("--------------");
                m_OutputHelper.WriteLine(expected);
                m_OutputHelper.WriteLine("--------------");
                m_OutputHelper.WriteLine("Actual:");
                m_OutputHelper.WriteLine("--------------");
                m_OutputHelper.WriteLine(actual);
                m_OutputHelper.WriteLine("--------------");

                Assert.Equal(expected, actual);
            }
        }
    }
}

