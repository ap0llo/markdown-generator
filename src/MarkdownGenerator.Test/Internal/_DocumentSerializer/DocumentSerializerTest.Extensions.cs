using Grynwald.MarkdownGenerator.Extensions;
using Xunit;
using static Grynwald.MarkdownGenerator.Extensions.FactoryMethods;
using static Grynwald.MarkdownGenerator.FactoryMethods;

namespace Grynwald.MarkdownGenerator.Test.Internal
{
    public partial class DocumentSerializerTest
    {
        [Fact]
        public void Admonitions_are_serialized_as_expected_01()
        {
            AssertToStringEquals(
                "!!! note\r\n" +
                "    Note content\r\n",

                Document(
                    Admonition(
                        "Note",
                        Paragraph("Note content")))
            );
        }

        [Fact]
        public void Admonitions_are_serialized_as_expected_02()
        {            
            AssertToStringEquals(
                "# Heading\r\n" +
                "\r\n" +
                "!!! note\r\n" +
                "    Note content\r\n",

                Document(
                    Heading(1, "Heading"),
                    Admonition(
                        "Note",
                        Paragraph("Note content")))
            );
        }

        [Fact]
        public void Admonitions_are_serialized_as_expected_03()
        {
            AssertToStringEquals(
                "# Heading\r\n" +
                "\r\n" +
                "!!! note \"Note title\"\r\n" +
                "    Note content\r\n",

                Document(
                    Heading(1, "Heading"),
                    Admonition(
                        "note",
                        "Note title",
                        Paragraph("Note content")))
            );
        }
    }

}
