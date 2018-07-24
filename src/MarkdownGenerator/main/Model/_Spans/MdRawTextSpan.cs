using System;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a span of raw Markdown content that will not be escaped before being written to the output
    /// </summary>
    public sealed class MdRawTextSpan : MdSpan
    {
        /// <summary>
        /// Gets the element's text
        /// </summary>
        public string RawMarkdown { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MdRawTextSpan"/>
        /// </summary>
        /// <param name="rawMarkdown">The span's content. The text will be written to the output without escaping.</param>
        public MdRawTextSpan(string rawMarkdown)
        {
            RawMarkdown = rawMarkdown ?? throw new ArgumentNullException(nameof(rawMarkdown));
        }
    }
}
