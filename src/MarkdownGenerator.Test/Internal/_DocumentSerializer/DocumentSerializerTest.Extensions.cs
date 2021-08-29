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


        [Fact]
        public void Task_list_items_in_bullet_lists_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "- [ ] Item 1\r\n" +
                "- [ ] Item 2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdTaskListItem("Item 1"),
                        new MdTaskListItem("Item 2")))
            );

        [Fact]
        public void Task_list_items_in_bullet_lists_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "- [ ] Item 1\r\n" +
                "- Item 2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdTaskListItem("Item 1"),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Task_list_items_in_bullet_lists_are_serialized_as_expected_03() =>
            AssertToStringEquals(
                "- [ ] Item 1, line 1  \r\n" +
                "  Item 1, line 2\r\n" +
                "- Item 2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdTaskListItem(
                            new MdParagraph("Item 1, line 1\r\nItem 1, line 2")
                        ),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Task_list_items_in_bullet_lists_are_serialized_as_expected_04() =>
            AssertToStringEquals(
                "- [ ] Item 1\r\n" +
                "  - [ ] Item 1.1\r\n" +
                "  - [ ] Item 1.2\r\n" +
                "- [ ] Item 2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdTaskListItem(
                            new MdParagraph("Item 1"),
                            new MdBulletList(
                                new MdTaskListItem("Item 1.1"),
                                new MdTaskListItem("Item 1.2"))),
                        new MdTaskListItem("Item 2")))
            );

        [Fact]
        public void Task_list_items_in_bullet_lists_are_serialized_as_expected_05() =>
            AssertToStringEquals(
                "- [ ] Item 1\r\n" +
                "- [x] Item 2\r\n",
                new MdDocument(
                    new MdBulletList(
                        new MdTaskListItem("Item 1"),
                        new MdTaskListItem("Item 2") { IsChecked = true }))
            );


        [Fact]
        public void Task_list_items_in_ordered_lists_are_serialized_as_expected_01() =>
            AssertToStringEquals(
                "1. [ ] Item 1\r\n" +
                "2. [ ] Item 2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdTaskListItem("Item 1"),
                        new MdTaskListItem("Item 2")))
            );

        [Fact]
        public void Task_list_items_in_ordered_lists_are_serialized_as_expected_02() =>
            AssertToStringEquals(
                "1. [ ] Item 1\r\n" +
                "2. Item 2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdTaskListItem("Item 1"),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Task_list_items_in_ordered_lists_are_serialized_as_expected_03() =>
            AssertToStringEquals(
                "1. [ ] Item 1, line 1  \r\n" +
                "   Item 1, line 2\r\n" +
                "2. Item 2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdTaskListItem(
                            new MdParagraph("Item 1, line 1\r\nItem 1, line 2")
                        ),
                        new MdListItem("Item 2")))
            );

        [Fact]
        public void Task_list_items_in_ordered_lists_are_serialized_as_expected_04() =>
            AssertToStringEquals(
                "1. [ ] Item 1\r\n" +
                "   1. [ ] Item 1.1\r\n" +
                "   2. [ ] Item 1.2\r\n" +
                "2. [ ] Item 2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdTaskListItem(
                            new MdParagraph("Item 1"),
                            new MdOrderedList(
                                new MdTaskListItem("Item 1.1"),
                                new MdTaskListItem("Item 1.2"))),
                        new MdTaskListItem("Item 2")))
            );

        [Fact]
        public void Task_list_items_in_ordered_lists_are_serialized_as_expected_05() =>
            AssertToStringEquals(
                "1. [ ] Item 1\r\n" +
                "2. [x] Item 2\r\n",
                new MdDocument(
                    new MdOrderedList(
                        new MdTaskListItem("Item 1"),
                        new MdTaskListItem("Item 2") { IsChecked = true }))
            );
    }
}
