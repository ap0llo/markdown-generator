using System;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a paragraph in a document
    /// </summary>
    public sealed class MdParagraph : MdBlock
    {                
        /// <summary>
        /// The paragraph's text
        /// </summary>
        public MdSpan Text { get; }


        public MdParagraph(string text) : this(new MdTextSpan(text))
        { }        

        public MdParagraph(params MdSpan[] spans) : this(new MdCompositeSpan(spans))
        { }

        public MdParagraph(MdSpan text) =>            
            Text = text ?? throw new ArgumentNullException(nameof(text));

        
    }
}
