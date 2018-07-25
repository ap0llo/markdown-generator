using System;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a inline code span 
    /// </summary>
    public class MdCodeSpan : MdSpan
    {
        /// <summary>
        /// The code span's content. The value will not be espaced.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MdCodeSpan"/>
        /// </summary>
        /// <param name="text">The content of the code span. The value will not be escaped.</param>
        public MdCodeSpan(string text) => 
            Text = text ?? throw new ArgumentNullException(nameof(text));
    }
}
