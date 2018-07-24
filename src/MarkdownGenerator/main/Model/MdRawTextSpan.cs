using System;
using System.Collections.Generic;
using System.Text;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdRawTextSpan : MdTextSpan
    {
        public string RawMarkdown { get; }

        public MdRawTextSpan(string rawMarkdown)
        {
            RawMarkdown = rawMarkdown ?? throw new ArgumentNullException(nameof(rawMarkdown));
        }
    }
}
