using System;
using System.Collections.Generic;
using System.Text;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a span that will be written to the output as a single line.
    /// All line breaks will be removed and replaced by spaces.
    /// Trailng line breaks are removed
    /// </summary>
    public sealed class MdSingleLineSpan : MdSpan
    {
        public MdSpan Content { get; }

        public MdSingleLineSpan(MdSpan content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }
    }
}
