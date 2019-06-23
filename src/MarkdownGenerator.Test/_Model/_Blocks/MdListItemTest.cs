﻿using System.Linq;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdListItemTest
    {
        [Fact]
        public void MdListItem_can_be_initialized_with_string_content_01()
        {
            var listItem = new MdListItem("Content");

            Assert.Single(listItem.Blocks);
            Assert.IsType<MdParagraph>(listItem.Blocks.Single());

            var paragraph = (MdParagraph)listItem.Blocks.Single();
            Assert.IsType<MdTextSpan>(paragraph.Text);

            var textSpan = (MdTextSpan)paragraph.Text;
            Assert.Equal("Content", textSpan.Text);
        }

        [Fact]
        public void MdListItem_can_be_initialized_with_string_content_02()
        {
            var listItem = new MdListItem("Content1", "Content2");

            Assert.Single(listItem.Blocks);
            Assert.IsType<MdParagraph>(listItem.Blocks.Single());

            var paragraph = (MdParagraph)listItem.Blocks.Single();
            Assert.IsType<MdCompositeSpan>(paragraph.Text);

            var compositeSpan = (MdCompositeSpan)paragraph.Text;

            Assert.Equal(2, compositeSpan.Spans.Count);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[0]);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[1]);

            Assert.Equal("Content1", (compositeSpan.Spans[0] as MdTextSpan).Text);
            Assert.Equal("Content2", (compositeSpan.Spans[1] as MdTextSpan).Text);
        }

        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdListItem(new MdParagraph());
            var instance2 = new MdListItem(new MdParagraph());
            var instance3 = new MdListItem(new MdParagraph(new MdTextSpan("Text")));

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdParagraph()));
        }
    }
}
