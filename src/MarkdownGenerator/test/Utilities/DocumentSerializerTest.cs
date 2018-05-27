using System;
using Xunit;
using Grynwald.MarkdownGenerator.Model;
using static Grynwald.MarkdownGenerator.Model.MdDSL;
using Grynwald.MarkdownGenerator.Utilities;
using System.IO;

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
        public void Simple_lists_are_serialized_as_expected() =>
            AssertToStringEquals(
                "- Item 1\r\n" +
                "- Item 2\r\n",
                Document(
                    List(
                        ListItem("Item 1"),
                        ListItem("Item 2")))
            );

        [Fact]
        public void Lists_are_surrounded_by_blank_lines() =>
            AssertToStringEquals(
                "# Heading\r\n" +
                "\r\n" +
                "- Item 1\r\n" +
                "- Item 2\r\n" +
                "\r\n" +
                "Paragraph\r\n",
                Document(
                    Heading("Heading", 1),
                    List(
                        ListItem("Item 1"),
                        ListItem("Item 2")
                    ),
                    Paragraph("Paragraph"))
            );

        [Fact]
        public void Multi_level_lists_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "- Item 1\r\n" +
                "  - Item 1.1\r\n" +
                "  - Item 1.2\r\n" +
                "- Item 2\r\n",
                Document(                    
                    List(
                        ListItem(
                            Paragraph("Item 1"),
                            List(
                                ListItem("Item 1.1"),
                                ListItem("Item 1.2"))),
                        ListItem("Item 2")))
            );

        [Fact]
        public void Multi_level_lists_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "- Item 1\r\n" +
                "  - Item 1.1\r\n" +
                "    - Item 1.1.1\r\n" +
                "  - Item 1.2\r\n" +
                "- Item 2\r\n",
                Document(
                    List(
                        ListItem(
                            Paragraph("Item 1"),
                            List(
                                ListItem(
                                    Paragraph("Item 1.1"),
                                    List(
                                        ListItem("Item 1.1.1"))),
                                ListItem("Item 1.2"))),
                        ListItem("Item 2")))
            );

        [Fact]
        public void Paragraphs_in_lists_can_contain_multiple_lines() =>
            AssertToStringEquals(
                "- Item 1 consists of  \r\n" +
                "  multiple lines\r\n" +
                "  - Item 1.1  \r\n" +
                "    as well\r\n",                 
                Document(
                    List(
                        ListItem(
                            Paragraph("Item 1 consists of\r\nmultiple lines"),
                            List(
                                ListItem(
                                    Paragraph("Item 1.1\r\nas well"))
                                ))))
            );

        [Fact]
        public void Multiple_paragraphs_in_list_items_are_serialized_correctly() =>
            AssertToStringEquals(
                "- Paragraph 1\r\n" +
                "\r\n" +
                "  Paragraph 2\r\n",
                Document(
                    List(
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
        public void Lists_can_contain_tables() =>
            AssertToStringEquals(
                "- ListItem1\r\n" +
                "\r\n" +
                "  | Column1 | Column2 |\r\n" +
                "  |---------|---------|\r\n" +
                "  | Cell1   |         |\r\n" +
                "  | Cell3   | Cell4   |\r\n",
                Document(
                    List(
                        ListItem(
                            Paragraph("ListItem1"),
                            Table(
                                Row("Column1", "Column2"),
                                Row("Cell1"),
                                Row("Cell3", "Cell4"))))));



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
