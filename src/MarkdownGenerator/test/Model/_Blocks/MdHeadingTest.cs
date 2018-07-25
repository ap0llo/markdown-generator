using Grynwald.MarkdownGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test.Model
{
    public class MdHeadingTest
    {
        [Fact]
        public void MdHeading_can_be_initialized_with_string_content()
        {
            var heading = new MdHeading("Content", 1);
            
            Assert.IsType<MdTextSpan>(heading.Text);
            
            var textSpan = (MdTextSpan)heading.Text;
            Assert.Equal("Content", textSpan.Text);
        }


        [Fact]
        public void MdHeading_can_be_initialized_with_span_content()
        {
            var text = new MdTextSpan("Content");
            var heading = new MdHeading(text, 1);

            Assert.Same(text, heading.Text);
        }
    }
}
