using System;
using System.Text.RegularExpressions;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a span that will be written to the output as a single line.
    /// All line breaks will be removed and replaced by spaces.
    /// Trailng line breaks are removed
    /// </summary>
    public sealed class MdSingleLineSpan : MdSpan
    {
        private static readonly Regex s_LineBreakPattern = new Regex(@"(\s)*[\r\n]+(\s)*", RegexOptions.Compiled);
        private static readonly Regex s_TrailingLineBreakRegex = new Regex(@"[\r\n]+$", RegexOptions.Compiled);


        public MdSpan Content { get; }


        public MdSingleLineSpan(MdSpan content) => 
            Content = content ?? throw new ArgumentNullException(nameof(content));


        public override string ToString() => ToString(MdSerializationOptions.Default);

        public override string ToString(MdSerializationOptions options)
        {
            var content = Content.ToString(options);

            // remove trailing line breaks
            content = s_TrailingLineBreakRegex.Replace(content, "");

            // replace other line breaks with spaces. 
            // If linebreaks are folowed/precedded by whitespace
            // replace whitespace and line break with a single
            // space
            content = s_LineBreakPattern.Replace(content, " ");

            return content;
        }

        internal override MdSpan DeepCopy() => new MdSingleLineSpan(Content.DeepCopy());
    }
}
