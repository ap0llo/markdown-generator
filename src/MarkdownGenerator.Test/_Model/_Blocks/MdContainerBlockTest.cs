﻿using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdContainerBlockTest
    {
        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdContainerBlock(new MdParagraph());
            var instance2 = new MdContainerBlock(new MdParagraph());
            var instance3 = new MdContainerBlock(new MdParagraph(new MdTextSpan("Text")));

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdParagraph()));
        }
    }
}
