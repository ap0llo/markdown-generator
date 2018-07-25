using Grynwald.MarkdownGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
{
    public class MdHeadingTest
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MdHeading_can_be_initialized_with_string_content_01(bool useFactoryMethods)
        {
            var heading = useFactoryMethods
                ? FactoryMethods.Heading("Content", 1)
                : new MdHeading("Content", 1);
            
            Assert.IsType<MdTextSpan>(heading.Text);
            
            var textSpan = (MdTextSpan)heading.Text;
            Assert.Equal("Content", textSpan.Text);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MdHeading_can_be_initialized_with_string_content_02(bool useFactoryMethods)
        {
            var heading = useFactoryMethods
                ? FactoryMethods.Heading(1, "Content")
                : new MdHeading(1, "Content");

            Assert.IsType<MdTextSpan>(heading.Text);

            var textSpan = (MdTextSpan)heading.Text;
            Assert.Equal("Content", textSpan.Text);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MdHeading_can_be_initialized_with_string_content_03(bool useFactoryMethods)
        {
            var heading = useFactoryMethods
                ? FactoryMethods.Heading(1, "Content1", "Content2")
                : new MdHeading(1, "Content1", "Content2");

            Assert.IsType<MdCompositeSpan>(heading.Text);
            var compositeSpan = (MdCompositeSpan)heading.Text;

            Assert.IsType<MdTextSpan>(compositeSpan.Spans[0]);
            Assert.IsType<MdTextSpan>(compositeSpan.Spans[1]);

            var textSpan1 = (MdTextSpan)compositeSpan.Spans[0];
            var textSpan2 = (MdTextSpan)compositeSpan.Spans[1];
            Assert.Equal("Content1", textSpan1.Text);
            Assert.Equal("Content2", textSpan2.Text);
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MdHeading_can_be_initialized_with_span_content(bool useFactoryMethods)
        {
            var text = new MdTextSpan("Content");

            var heading = useFactoryMethods
                ? FactoryMethods.Heading(text, 1)
                : new MdHeading(text, 1);

            Assert.Same(text, heading.Text);
        }      
    }
}
