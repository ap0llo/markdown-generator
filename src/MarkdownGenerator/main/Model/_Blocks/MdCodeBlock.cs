using System;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a fenced code block 
    /// </summary>
    public sealed class MdCodeBlock : MdLeafBlock
    {
        /// <summary>
        /// The content of the code block
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The info string for the code block (typically used to specify the language of the code in the block)
        /// </summary>
        public string InfoString { get; }


        public MdCodeBlock(string text) : this(text, null)
        { }

        public MdCodeBlock(string text, string infoString)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            InfoString = infoString;
        }
    }
}
