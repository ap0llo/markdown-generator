using Grynwald.MarkdownGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
{
    public class EnumerableExtensionsTest
    {

        [Fact]
        public void Join_returns_the_expected_span_01()
        {
            // ARRANGE
            var spansToJoin = new[] { new MdTextSpan("text") };

            // ACT
            var joined = spansToJoin.Join();

            // ASSERT
            Assert.IsType<MdTextSpan>(joined);
            Assert.Same(spansToJoin[0], joined);
        }

        [Fact]
        public void Join_returns_the_expected_span_02()
        {
            // ARRANGE
            var spansToJoin = Enumerable.Empty<MdSpan>();

            // ACT
            var joined = spansToJoin.Join();

            // ASSERT
            Assert.IsType<MdEmptySpan>(joined);            
        }

        [Fact]
        public void Join_returns_the_expected_span_03()
        {
            // ARRANGE
            var spansToJoin = new[]
            {
                new MdTextSpan("text"),
                new MdTextSpan("more text")
            };

            // ACT
            var joined = spansToJoin.Join();

            // ASSERT
            Assert.IsType<MdCompositeSpan>(joined);
            var compositeSpan = (MdCompositeSpan)joined;
            Assert.Equal(2, compositeSpan.Spans.Count);
            Assert.Same(spansToJoin[0], compositeSpan.Spans[0]);
            Assert.Same(spansToJoin[1], compositeSpan.Spans[1]);
        }

        [Fact]
        public void Join_returns_the_expected_span_04()
        {
            // ARRANGE
            var spansToJoin = new[] { new MdTextSpan("text") };

            // ACT
            var joined = spansToJoin.Join(separator: ",");

            // ASSERT
            Assert.IsType<MdTextSpan>(joined);
            Assert.Same(spansToJoin[0], joined);
        }

        [Fact]
        public void Join_returns_the_expected_span_05()
        {
            // ARRANGE
            var spansToJoin = Enumerable.Empty<MdSpan>();

            // ACT
            var joined = spansToJoin.Join(separator: ",");

            // ASSERT
            Assert.IsType<MdEmptySpan>(joined);
        }

        [Fact]
        public void Join_returns_the_expected_span_06()
        {
            // ARRANGE
            var spansToJoin = new[]
            {
                new MdTextSpan("text"),
                new MdTextSpan("more text")
            };

            // ACT
            var joined = spansToJoin.Join(separator: ",");

            // ASSERT
            Assert.IsType<MdCompositeSpan>(joined);

            var compositeSpan = (MdCompositeSpan)joined;
            Assert.Equal(3, compositeSpan.Spans.Count);

            Assert.Same(spansToJoin[0], compositeSpan.Spans[0]);

            Assert.IsType<MdTextSpan>(compositeSpan.Spans[1]);
            Assert.Equal(",", ((MdTextSpan)compositeSpan.Spans[1]).Text);

            Assert.Same(spansToJoin[1], compositeSpan.Spans[2]);
        }

        [Fact]
        public void Join_returns_the_expected_span_07()
        {
            // ARRANGE
            var spansToJoin = new[]
            {
                new MdTextSpan("text"),  
                new MdTextSpan("more text"), 
                new MdTextSpan("even more text") 
            };

            // ACT
            var joined = spansToJoin.Join(separator: ",");

            // ASSERT
            Assert.IsType<MdCompositeSpan>(joined);
            var compositeSpan = (MdCompositeSpan)joined;
            Assert.Equal(5, compositeSpan.Spans.Count);

            Assert.Same(spansToJoin[0], compositeSpan.Spans[0]);

            Assert.IsType<MdTextSpan>(compositeSpan.Spans[1]);
            Assert.Equal(",", ((MdTextSpan)compositeSpan.Spans[1]).Text);

            Assert.Same(spansToJoin[1], compositeSpan.Spans[2]);

            Assert.IsType<MdTextSpan>(compositeSpan.Spans[3]);
            Assert.Equal(",", ((MdTextSpan)compositeSpan.Spans[3]).Text);

            Assert.Same(spansToJoin[2], compositeSpan.Spans[4]);
        }


        [Fact]
        public void Join_returns_the_expected_span_08()
        {
            // ARRANGE
            var spansToJoin = new[] { new MdTextSpan("text") };

            // ACT
            var joined = spansToJoin.Join(separator: new MdStrongEmphasisSpan(new MdTextSpan("separator")));

            // ASSERT
            Assert.IsType<MdTextSpan>(joined);
            Assert.Same(spansToJoin[0], joined);
        }

        [Fact]
        public void Join_returns_the_expected_span_09()
        {
            // ARRANGE
            var spansToJoin = Enumerable.Empty<MdSpan>();

            // ACT
            var joined = spansToJoin.Join(separator: new MdStrongEmphasisSpan(new MdTextSpan("separator")));

            // ASSERT
            Assert.IsType<MdEmptySpan>(joined);
        }

        [Fact]
        public void Join_returns_the_expected_span_10()
        {
            // ARRANGE
            var spansToJoin = new[]
            {
                new MdTextSpan("text"),
                new MdTextSpan("more text")
            };

            // ACT
            var joined = spansToJoin.Join(separator: new MdStrongEmphasisSpan(new MdTextSpan("separator")));

            // ASSERT
            Assert.IsType<MdCompositeSpan>(joined);

            var compositeSpan = (MdCompositeSpan)joined;
            Assert.Equal(3, compositeSpan.Spans.Count);

            Assert.Same(spansToJoin[0], compositeSpan.Spans[0]);

            Assert.IsType<MdStrongEmphasisSpan>(compositeSpan.Spans[1]);
            Assert.IsType<MdTextSpan>(((MdStrongEmphasisSpan)compositeSpan.Spans[1]).Text);
            Assert.Equal("separator", ((MdTextSpan)((MdStrongEmphasisSpan)compositeSpan.Spans[1]).Text).Text);


            Assert.Same(spansToJoin[1], compositeSpan.Spans[2]);
        }

        [Fact]
        public void Join_returns_the_expected_span_11()
        {
            // ARRANGE
            var spansToJoin = new[]
            {
                new MdTextSpan("text"),
                new MdTextSpan("more text"),
                new MdTextSpan("even more text")
            };

            // ACT
            var joined = spansToJoin.Join(separator: new MdStrongEmphasisSpan(new MdTextSpan("separator")));

            // ASSERT
            Assert.IsType<MdCompositeSpan>(joined);
            var compositeSpan = (MdCompositeSpan)joined;
            Assert.Equal(5, compositeSpan.Spans.Count);

            Assert.Same(spansToJoin[0], compositeSpan.Spans[0]);

            Assert.IsType<MdStrongEmphasisSpan>(compositeSpan.Spans[1]);
            Assert.IsType<MdTextSpan>(((MdStrongEmphasisSpan)compositeSpan.Spans[1]).Text);
            Assert.Equal("separator", ((MdTextSpan)((MdStrongEmphasisSpan)compositeSpan.Spans[1]).Text).Text);

            Assert.Same(spansToJoin[1], compositeSpan.Spans[2]);

            Assert.IsType<MdStrongEmphasisSpan>(compositeSpan.Spans[3]);
            Assert.IsType<MdTextSpan>(((MdStrongEmphasisSpan)compositeSpan.Spans[3]).Text);
            Assert.Equal("separator", ((MdTextSpan)((MdStrongEmphasisSpan)compositeSpan.Spans[3]).Text).Text);

            Assert.Same(spansToJoin[2], compositeSpan.Spans[4]);
        }

    }
}
