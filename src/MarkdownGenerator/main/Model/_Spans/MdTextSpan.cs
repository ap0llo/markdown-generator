using System;
using System.Collections.Generic;
using System.Text;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents an (unformatted) text element which's content will be 
    /// escaped before being written to the output
    /// </summary>
    public class MdTextSpan : MdSpan
    {
        /// <summary>
        /// Gets the element's content.
        /// The value will be escaped before being written to the output.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTextSpan"/>
        /// </summary>
        /// <param name="text">The element's content. The value will be escaped before being written to the output.</param>
        public MdTextSpan(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
