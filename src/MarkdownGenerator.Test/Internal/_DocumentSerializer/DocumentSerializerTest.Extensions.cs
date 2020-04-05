using Grynwald.MarkdownGenerator.Extensions;
using Xunit;

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

                new MdDocument(
                    new MdAdmonition(
                        "Note",
                        new MdParagraph("Note content")))
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

                new MdDocument(
                    new MdHeading(1, "Heading"),
                    new MdAdmonition(
                        "Note",
                        new MdParagraph("Note content")))
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

                new MdDocument(
                    new MdHeading(1, "Heading"),
                    new MdAdmonition(
                        "note",
                        "Note title",
                        new MdParagraph("Note content")))
            );
        }
    }
}
