using System;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a paragraph in a markdown document.
    /// For specification see https://spec.commonmark.org/0.28/#paragraphs
    /// </summary>
    public sealed class MdParagraph : MdBlock
    {                
        /// <summary>
        /// Gets the paragraph's text
        /// </summary>
        public MdSpan Text { get; }
        

        /// <summary>
        /// Initializes a new instance of <see cref="MdParagraph"/> with the specified content.
        /// </summary>
        /// <param name="spans">
        /// One or more instances of <see cref="MdSpan"/>.
        /// As <see cref="MdParagraph"/> only supports a single span instance as text,
        /// the spans will be wrapped in an instance of <see cref="MdCompositeSpan"/>.
        /// </param>
        public MdParagraph(params MdSpan[] spans) : this(new MdCompositeSpan(spans))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdParagraph"/> with the specified content.
        /// </summary>
        /// <param name="text">The paragraphs content</param>
        public MdParagraph(MdSpan text) =>            
            Text = text ?? throw new ArgumentNullException(nameof(text));        
    }
}
