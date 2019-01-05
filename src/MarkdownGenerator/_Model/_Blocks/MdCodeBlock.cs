using System;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a fenced code block.
    /// For specification see https://spec.commonmark.org/0.28/#fenced-code-blocks
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


        /// <summary>
        /// Initializes a new instance of <see cref="MdCodeBlock"/> with the specified text.
        /// </summary>
        /// <param name="text">The code blocks content</param>
        public MdCodeBlock(string text) : this(text, null)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdCodeBlock"/>.
        /// </summary>
        /// <param name="text">The code blocks content</param>
        /// <param name="infoString">
        /// The code blocks info string, typically used to indicate the language of the code block
        /// </param>
        public MdCodeBlock(string text, string infoString)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            InfoString = infoString;
        }
    }
}
