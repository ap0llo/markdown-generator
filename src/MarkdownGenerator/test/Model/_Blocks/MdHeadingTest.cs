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
        public void MdHeading_can_be_initialized_with_string_content(bool useFactoryMethods)
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
