using System;
using System.IO;
using System.Linq;
using Grynwald.MarkdownGenerator.Internal;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdContainerBlockBaseTest
    {
        private class TestContainerBlock : MdContainerBlockBase
        {
            public TestContainerBlock()
            { }

            public TestContainerBlock(object content) : base(content)
            { }

            public TestContainerBlock(params object[] content) : base(content)
            { }

            public override bool DeepEquals(MdBlock other) => throw new NotImplementedException();

            internal override void Accept(IBlockVisitor visitor) => throw new NotImplementedException();
        }

        // empty
        // Block
        // IEnumerbale of block
        // span
        // string
        // combination

        [Fact]
        public void Block_can_be_initialized_without_content()
        {
            // ARRANGE

            // ACT
            var instance = new TestContainerBlock();

            // ASSERT
            Assert.NotNull(instance.Blocks);
            Assert.Empty(instance.Blocks);
        }

        [Fact]
        public void Block_can_be_initialized_with_a_single_block()
        {
            // ARRANGE
            var block = new MdParagraph();

            // ACT
            var instance = new TestContainerBlock(block);

            // ASSERT
            Assert.NotNull(instance.Blocks);
            Assert.Single(instance.Blocks);
            Assert.Same(block, instance.Blocks.Single());
        }

        [Fact]
        public void Block_can_be_initialized_with_a_multiple_blocks()
        {
            // ARRANGE
            var block1 = new MdParagraph();
            var block2 = new MdParagraph();

            // ACT
            var instance = new TestContainerBlock(block1, block2);

            // ASSERT
            Assert.NotNull(instance.Blocks);
            Assert.Equal(2, instance.Blocks.Count);
            Assert.Same(block1, instance.Blocks.First());
            Assert.Same(block2, instance.Blocks.Last());
        }

        [Fact]
        public void Block_can_be_initialized_with_a_enumerable_of_blocks()
        {
            // ARRANGE
            var blocks = new[] { new MdParagraph(), new MdParagraph() };

            // ACT
            var instance = new TestContainerBlock(blocks);

            // ASSERT
            Assert.NotNull(instance.Blocks);
            Assert.Equal(2, instance.Blocks.Count);
            Assert.Same(blocks[0], instance.Blocks.First());
            Assert.Same(blocks[1], instance.Blocks.Last());
        }

        [Fact]
        public void Block_can_be_initialized_with_multiple_enumerables_of_blocks()
        {
            // ARRANGE
            var blocks1 = new[] { new MdParagraph(), new MdParagraph() };
            var blocks2 = new[] { new MdParagraph(), new MdParagraph() };

            // ACT
            var instance = new TestContainerBlock(blocks1, blocks2);

            // ASSERT
            Assert.NotNull(instance.Blocks);
            Assert.Equal(4, instance.Blocks.Count);
            Assert.Same(blocks1[0], instance.Blocks.Skip(0).First());
            Assert.Same(blocks1[1], instance.Blocks.Skip(1).First());
            Assert.Same(blocks2[0], instance.Blocks.Skip(2).First());
            Assert.Same(blocks2[1], instance.Blocks.Skip(3).First());
        }

        [Fact]
        public void Block_can_be_initialized_with_a_span()
        {
            // ARRANGE
            var content = new MdTextSpan("Content");

            // ACT
            var instance = new TestContainerBlock(content);

            // ASSERT
            Assert.NotNull(instance.Blocks);
            Assert.Single(instance.Blocks);
            Assert.IsType<MdParagraph>(instance.Blocks.Single());

            var paragraph = (MdParagraph)instance.Blocks.Single();
            Assert.True(new MdCompositeSpan(content).DeepEquals(paragraph.Text));
        }

        [Fact]
        public void Block_can_be_initialized_with_multiple_spans()
        {
            // ARRANGE
            var content1 = new MdTextSpan("Content 1");
            var content2 = new MdTextSpan("Content 2");

            // ACT
            var instance = new TestContainerBlock(content1, content2);

            // ASSERT
            Assert.NotNull(instance.Blocks);
            Assert.Single(instance.Blocks);
            Assert.IsType<MdParagraph>(instance.Blocks.Single());

            var paragraph = (MdParagraph)instance.Blocks.Single();

            // MdParagraph wraps content into a CompositeSpan
            Assert.IsType<MdCompositeSpan>(paragraph.Text);
            var compositeSpan = (MdCompositeSpan)paragraph.Text;
            Assert.Same(content1, compositeSpan.First());
            Assert.Same(content2, compositeSpan.Last());
        }

        [Fact]
        public void Block_can_be_initialized_with_a_enumerable_of_spans()
        {
            // ARRANGE
            var content = new[]
            {
                new MdTextSpan("Content 1"),
                new MdTextSpan("Content 2")
            };

            // ACT
            var instance = new TestContainerBlock(content);

            // ASSERT
            Assert.NotNull(instance.Blocks);
            Assert.Single(instance.Blocks);
            Assert.IsType<MdParagraph>(instance.Blocks.Single());

            var paragraph = (MdParagraph)instance.Blocks.Single();

            // MdParagraph wraps content into a CompositeSpan
            Assert.IsType<MdCompositeSpan>(paragraph.Text);
            var compositeSpan = (MdCompositeSpan)paragraph.Text;
            Assert.Equal(2, compositeSpan.Count);
            Assert.Same(content[0], compositeSpan.First());
            Assert.Same(content[1], compositeSpan.Last());
        }

        [Fact]
        public void Block_can_be_initialized_with_multiple_enumerables_of_spans()
        {
            // ARRANGE
            var content1 = new[]
            {
                new MdTextSpan("Content 1"),
                new MdTextSpan("Content 2")
            };

            var content2 = new[]
            {
                new MdTextSpan("Content 3"),
                new MdTextSpan("Content 4")
            };

            // ACT
            var instance = new TestContainerBlock(content1, content2);

            // ASSERT
            Assert.NotNull(instance.Blocks);
            Assert.Single(instance.Blocks);
            Assert.IsType<MdParagraph>(instance.Blocks.Single());

            var paragraph = (MdParagraph)instance.Blocks.Single();

            // MdParagraph wraps content into a CompositeSpan
            Assert.IsType<MdCompositeSpan>(paragraph.Text);
            var compositeSpan = (MdCompositeSpan)paragraph.Text;
            Assert.Equal(4, compositeSpan.Count);
            Assert.Same(content1[0], compositeSpan.Skip(0).First());
            Assert.Same(content1[1], compositeSpan.Skip(1).First());
            Assert.Same(content2[0], compositeSpan.Skip(2).First());
            Assert.Same(content2[1], compositeSpan.Skip(3).First());
        }

        [Fact]
        public void Block_can_be_initialized_with_a_string()
        {
            // ARRANGE
            var content = "Lorem ipsum";

            // ACT
            var instance = new TestContainerBlock(content);

            // ASSERT
            Assert.NotNull(instance.Blocks);
            Assert.Single(instance.Blocks);
            Assert.IsType<MdParagraph>(instance.Blocks.Single());

            var paragraph = (MdParagraph)instance.Blocks.Single();
            Assert.IsType<MdCompositeSpan>(paragraph.Text);
            var compositeSpan = (MdCompositeSpan)paragraph.Text;
            Assert.Single(compositeSpan);
            Assert.IsType<MdTextSpan>(compositeSpan.Single());
            Assert.Equal(content, ((MdTextSpan)compositeSpan.Single()).Text);
        }

        [Fact]
        public void Block_can_be_initialized_with_multiple_strings()
        {
            // ARRANGE
            var content1 = "Content1";
            var content2 = "Content2";

            // ACT
            var block = new TestContainerBlock(content1, content2);

            // ASSERT
            Assert.NotNull(block.Blocks);
            Assert.Single(block.Blocks);
            Assert.IsType<MdParagraph>(block.Blocks.Single());

            var paragraph = (MdParagraph)block.Blocks.Single();
            Assert.IsType<MdCompositeSpan>(paragraph.Text);

            var compositeSpan = (MdCompositeSpan)paragraph.Text;

            Assert.Equal(2, compositeSpan.Spans.Count);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[0]);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[1]);

            Assert.Equal(content1, (compositeSpan.Spans[0] as MdTextSpan).Text);
            Assert.Equal(content2, (compositeSpan.Spans[1] as MdTextSpan).Text);
        }

        [Fact]
        public void Block_can_be_initialized_with_an_enumerable_of_strings()
        {
            // ARRANGE
            var content = new[] { "Content1", "Content2" };

            // ACT
            var block = new TestContainerBlock(content);

            // ASSERT
            Assert.NotNull(block.Blocks);
            Assert.Single(block.Blocks);
            Assert.IsType<MdParagraph>(block.Blocks.Single());

            var paragraph = (MdParagraph)block.Blocks.Single();
            Assert.IsType<MdCompositeSpan>(paragraph.Text);

            var compositeSpan = (MdCompositeSpan)paragraph.Text;

            Assert.Equal(2, compositeSpan.Spans.Count);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[0]);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[1]);

            Assert.Equal(content[0], (compositeSpan.Spans[0] as MdTextSpan).Text);
            Assert.Equal(content[1], (compositeSpan.Spans[1] as MdTextSpan).Text);
        }

        [Fact]
        public void Block_can_be_initilaized_with_mixed_content()
        {
            // ARRANGE
            var content1 = "Content1";
            var content2 = new MdParagraph(new MdTextSpan("Content2"));
            var content3 = new[] { new MdStrongEmphasisSpan("Content3") };

            // ACT
            var instance = new TestContainerBlock(content1, content2, content3);

            // ASSERT
            Assert.NotNull(instance);
            Assert.Equal(2, instance.Blocks.Count);
            Assert.IsType<MdParagraph>(instance.Blocks.First());
            Assert.IsType<MdParagraph>(instance.Blocks.Last());

            var paragraph1 = (MdParagraph)instance.Blocks.First();
            Assert.True(new MdCompositeSpan(new MdTextSpan(content1)).DeepEquals(paragraph1.Text));

            var paragraph2 = (MdParagraph)instance.Blocks.Last();
            Assert.Same(content2, paragraph2);
            Assert.IsType<MdCompositeSpan>(paragraph2.Text);
            var compositeSpan = (MdCompositeSpan)paragraph2.Text;
            Assert.Equal(2, compositeSpan.Count);
            Assert.IsType<MdTextSpan>(compositeSpan.First());
            Assert.Equal("Content2", ((MdTextSpan)compositeSpan.First()).Text);
            Assert.Same(content3[0], compositeSpan.Last());
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData((byte)8)]
        [InlineData((sbyte)8)]
        [InlineData('c')]
        [InlineData(1.2d)]
        [InlineData(1.2f)]
        [InlineData(123)]
        [InlineData((uint)123)]
        [InlineData(123L)]
        [InlineData((ulong)123L)]
        [InlineData((short)23)]
        [InlineData((ushort)23)]
        [InlineData("Content")]
        public void Block_can_be_initilaized_with_simple_content(object content)
        {
            // ARRANGE
            
            // ACT
            var instance = new TestContainerBlock(content);

            // ASSERT
            Assert.NotNull(instance);
            Assert.Single(instance.Blocks);
            Assert.IsType<MdParagraph>(instance.Blocks.Single());

            var paragraph = (MdParagraph)instance.Blocks.Single();
            Assert.IsType<MdCompositeSpan>(paragraph.Text);
            var compositeSpan= (MdCompositeSpan)paragraph.Text;
            
            var textSpan = (MdTextSpan)compositeSpan.Single();
            Assert.Equal(content.ToString(), textSpan.Text);
        }


        [Fact]
        public void Exception_is_thrown_when_unsupported_content_is_added()
        {
            // ARRANGE
            var content = new FileInfo("someFile.ext");

            // ACT / ASSERT
            Assert.Throws<ArgumentException>(() => new TestContainerBlock(content));
        }

        [Fact]
        public void Exception_is_thrown_when_unsupported_content_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new TestContainerBlock(null));
            Assert.Throws<ArgumentNullException>(() => new TestContainerBlock(null, null));
        }
    }
}
