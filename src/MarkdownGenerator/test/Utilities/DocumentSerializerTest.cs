using System.IO;
using System.Linq;
using Xunit;
using Grynwald.MarkdownGenerator.Model;
using Grynwald.MarkdownGenerator.Utilities;
using static Grynwald.MarkdownGenerator.FactoryMethods;

namespace Grynwald.MarkdownGenerator.Test.Model
{
    public class DocumentSerializerTest
    {
        [Fact]
        public void Headings_are_serialized_as_expected() => 
            AssertToStringEquals(
                "# Heading 1\r\n",
                Document(Heading("Heading 1", 1))
            );

        [Fact]
        public void Paragraphs_are_serialized_as_expected() =>
            AssertToStringEquals(
                "Paragraph\r\n",
                Document(Paragraph("Paragraph"))
            );

        [Fact]
        public void Multiple_paragraphs_are_serialized_as_expected() =>
            AssertToStringEquals(
                "Paragraph1\r\n" +
                "\r\n" +
                "Paragraph2\r\n",
                Document(
                    Paragraph("Paragraph1"),
                    Paragraph("Paragraph2"))
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
                Document(
                    Heading("Heading 1", 1),
                    Paragraph("Paragraph1"),
                    Heading("Heading 2", 2),
                    Paragraph("Paragraph2"))
            );

        [Fact]
        public void Bullet_lists_are_serialized_as_expected() =>
            AssertToStringEquals(
                "- Item 1\r\n" +
                "- Item 2\r\n",
                Document(
                    BulletList(
                        ListItem("Item 1"),
                        ListItem("Item 2")))
            );

        [Fact]
        public void Ordered_lists_are_serialized_as_expected() =>
            AssertToStringEquals(
                "1. Item 1\r\n" +
                "2. Item 2\r\n",
                Document(
                    OrderedList(
                        ListItem("Item 1"),
                        ListItem("Item 2")))
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
                Document(
                    Heading("Heading", 1),
                    BulletList(
                        ListItem("Item 1"),
                        ListItem("Item 2")
                    ),
                    Paragraph("Paragraph"))
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
                Document(
                    Heading("Heading", 1),
                    OrderedList(
                        ListItem("Item 1"),
                        ListItem("Item 2")
                    ),
                    Paragraph("Paragraph"))
            );

        [Fact]
        public void Multi_level_bullet_lists_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "- Item 1\r\n" +
                "  - Item 1.1\r\n" +
                "  - Item 1.2\r\n" +
                "- Item 2\r\n",
                Document(                    
                    BulletList(
                        ListItem(
                            Paragraph("Item 1"),
                            BulletList(
                                ListItem("Item 1.1"),
                                ListItem("Item 1.2"))),
                        ListItem("Item 2")))
            );

        [Fact]
        public void Multi_level_ordered_lists_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "1. Item 1\r\n" +
                "   1. Item 1.1\r\n" +
                "   2. Item 1.2\r\n" +
                "2. Item 2\r\n",
                Document(
                    OrderedList(
                        ListItem(
                            Paragraph("Item 1"),
                            OrderedList(
                                ListItem("Item 1.1"),
                                ListItem("Item 1.2"))),
                        ListItem("Item 2")))
            );

        [Fact]
        public void Multi_bullet_level_lists_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "- Item 1\r\n" +
                "  - Item 1.1\r\n" +
                "    - Item 1.1.1\r\n" +
                "  - Item 1.2\r\n" +
                "- Item 2\r\n",
                Document(
                    BulletList(
                        ListItem(
                            Paragraph("Item 1"),
                            BulletList(
                                ListItem(
                                    Paragraph("Item 1.1"),
                                    BulletList(
                                        ListItem("Item 1.1.1"))),
                                ListItem("Item 1.2"))),
                        ListItem("Item 2")))
            );

        [Fact]
        public void Multi_level_ordered_lists_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "1. Item 1\r\n" +
                "   1. Item 1.1\r\n" +
                "      1. Item 1.1.1\r\n" +
                "   2. Item 1.2\r\n" +
                "2. Item 2\r\n",
                Document(
                    OrderedList(
                        ListItem(
                            Paragraph("Item 1"),
                            OrderedList(
                                ListItem(
                                    Paragraph("Item 1.1"),
                                    OrderedList(
                                        ListItem("Item 1.1.1"))),
                                ListItem("Item 1.2"))),
                        ListItem("Item 2")))
            );

        [Fact]
        public void Ordered_lists_can_contain_bullet_lists() =>
            AssertToStringEquals(
                "1. Item 1\r\n" +
                "   - Item 1.1\r\n" +
                "   - Item 1.2\r\n" +
                "2. Item 2\r\n",
                Document(
                    OrderedList(
                        ListItem(
                            Paragraph("Item 1"),
                            BulletList(
                                ListItem("Item 1.1"),
                                ListItem("Item 1.2"))),
                        ListItem("Item 2")))
            );

        [Fact]
        public void Paragraphs_in_bullet_lists_can_contain_multiple_lines() =>
            AssertToStringEquals(
                "- Item 1 consists of  \r\n" +
                "  multiple lines\r\n" +
                "  - Item 1.1  \r\n" +
                "    as well\r\n",                 
                Document(
                    BulletList(
                        ListItem(
                            Paragraph("Item 1 consists of\r\nmultiple lines"),
                            BulletList(
                                ListItem(
                                    Paragraph("Item 1.1\r\nas well"))
                                ))))
            );

        [Fact]
        public void Paragraphs_in_ordered_lists_can_contain_multiple_lines() =>
            AssertToStringEquals(
                "1. Item 1 consists of  \r\n" +
                "   multiple lines\r\n" +
                "   1. Item 1.1  \r\n" +
                "      as well\r\n",
                Document(
                    OrderedList(
                        ListItem(
                            Paragraph("Item 1 consists of\r\nmultiple lines"),
                            OrderedList(
                                ListItem(
                                    Paragraph("Item 1.1\r\nas well"))
                                ))))
            );

        [Fact]
        public void Multiple_paragraphs_in_bullet_list_items_are_serialized_correctly() =>
            AssertToStringEquals(
                "- Paragraph 1\r\n" +
                "\r\n" +
                "  Paragraph 2\r\n",
                Document(
                    BulletList(
                        ListItem(
                            Paragraph("Paragraph 1"),
                            Paragraph("Paragraph 2"))))
            );

        [Fact]
        public void Multiple_paragraphs_in_ordered_list_items_are_serialized_correctly() =>
            AssertToStringEquals(
                "1. Paragraph 1\r\n" +
                "\r\n" +
                "   Paragraph 2\r\n",
                Document(
                    OrderedList(
                        ListItem(
                            Paragraph("Paragraph 1"),
                            Paragraph("Paragraph 2"))))
            );

        [Fact]
        public void Line_breaks_in_paragraphs_are_replaced_with_hard_line_breaks() =>
            AssertToStringEquals(
                "Line1  \r\n" +
                "Line2\r\n",                
                Document(Paragraph("Line1\r\nLine2"))
            );

        [Fact]
        public void Code_blocks_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "```\r\n" +
                "Line1\r\n" +
                "Line2\r\n" +
                "```\r\n",
                Document(CodeBlock("Line1\r\nLine2"))
            );

        [Fact]
        public void Code_blocks_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "```xml\r\n" +
                "Line1\r\n" +
                "Line2\r\n" +
                "```\r\n",
                Document(CodeBlock("Line1\r\nLine2", "xml"))
            );

        [Fact]
        public void Tables_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "| Column1 | Column2 |\r\n" +
                "|---------|---------|\r\n" +
                "| Cell1   | Cell2   |\r\n",
                Document(
                    Table(
                        Row("Column1", "Column2"),
                        Row("Cell1", "Cell2")))
            );

        [Fact]
        public void Tables_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "| Column1 | Column2 |\r\n" +
                "|---------|---------|\r\n" +
                "| Cell1   |         |\r\n" +
                "| Cell3   | Cell4   |\r\n",
                Document(
                    Table(
                        Row("Column1", "Column2"),
                        Row("Cell1"),
                        Row("Cell3", "Cell4")))
            );

        [Fact]
        public void Bullet_lists_can_contain_tables() =>
            AssertToStringEquals(
                "- ListItem1\r\n" +
                "\r\n" +
                "  | Column1 | Column2 |\r\n" +
                "  |---------|---------|\r\n" +
                "  | Cell1   |         |\r\n" +
                "  | Cell3   | Cell4   |\r\n",
                Document(
                    BulletList(
                        ListItem(
                            Paragraph("ListItem1"),
                            Table(
                                Row("Column1", "Column2"),
                                Row("Cell1"),
                                Row("Cell3", "Cell4"))))));

        [Fact]
        public void Ordered_lists_can_contain_tables() =>
            AssertToStringEquals(
                "1. ListItem1\r\n" +
                "\r\n" +
                "   | Column1 | Column2 |\r\n" +
                "   |---------|---------|\r\n" +
                "   | Cell1   |         |\r\n" +
                "   | Cell3   | Cell4   |\r\n",
                Document(
                    OrderedList(
                        ListItem(
                            Paragraph("ListItem1"),
                            Table(
                                Row("Column1", "Column2"),
                                Row("Cell1"),
                                Row("Cell3", "Cell4"))))));


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
                Document(
                    OrderedList(Enumerable.Repeat("Item", 11).Select(ListItem))
                )
            );

        [Fact]
        public void ThematicBreaks_are_serialized_as_expected() =>
            AssertToStringEquals(
                "Paragraph\r\n" +
                "\r\n" +
                "---\r\n" +
                "\r\n" +
                "Paragraph\r\n",
                Document(
                    Paragraph("Paragraph"),
                    ThematicBreak(),
                    Paragraph("Paragraph"))
            );


        [Fact]
        public void BlockQuotes_are_serialized_as_expected() =>
            AssertToStringEquals(
                "> Quote\r\n",
                Document(BlockQuote("Quote"))
            );

        [Fact]
        public void BlockQuotes_can_contain_lists() =>
            AssertToStringEquals(
                "> Quote\r\n" +
                ">\r\n" +
                "> - Item1\r\n" +
                "> - Item2\r\n",
                Document(
                    BlockQuote(
                        Paragraph("Quote"),
                        BulletList(
                            ListItem("Item1"),
                            ListItem("Item2"))))
            );

        [Fact]
        public void Bullet_lists_can_contain_BlockQuotes() =>
            AssertToStringEquals(
                "- Item1\r\n" +
                "\r\n" +
                "  > Quote1\r\n" +
                "  >\r\n" +
                "  > Quote2\r\n",
                Document(
                    BulletList(
                        ListItem(
                            Paragraph("Item1"),
                            BlockQuote(
                                Paragraph("Quote1"),
                                Paragraph("Quote2")))))
            );

        [Fact]
        public void Ordered_lists_can_contain_BlockQuotes() =>
            AssertToStringEquals(
                "1. Item1\r\n" +
                "\r\n" +
                "   > Quote1\r\n" +
                "   >\r\n" +
                "   > Quote2\r\n",
                Document(
                    OrderedList(
                        ListItem(
                            Paragraph("Item1"),
                            BlockQuote(
                                Paragraph("Quote1"),
                                Paragraph("Quote2")))))
            );

        private void AssertToStringEquals(string expected, MdDocument document)
        {
            using (var writer = new StringWriter())
            {
                var serializer = new DocumentSerializer(writer);
                serializer.Serialize(document);

                var actual = writer.ToString();            
                Assert.Equal(expected, actual);
            }

        }
    }
}
