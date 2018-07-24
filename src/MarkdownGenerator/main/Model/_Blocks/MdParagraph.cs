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
        public string Text { get; }


        public MdParagraph(string text) =>
            //TODO: handle blank lines within paragraph  
            Text = text ?? throw new ArgumentNullException(nameof(text));
    }
}
