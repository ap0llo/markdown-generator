using System;
using System.Text.RegularExpressions;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a span that will be written to the output as a single line.
    /// All line breaks will be removed and replaced by spaces.
    /// Trailing line breaks are removed
    /// </summary>
    public sealed class MdSingleLineSpan : MdSpan
    {
        private static readonly Regex s_LineBreakPattern = new Regex(@"(\s)*[\r\n]+(\s)*", RegexOptions.Compiled);
        private static readonly Regex s_TrailingLineBreakRegex = new Regex(@"[\r\n]+$", RegexOptions.Compiled);

        /// <summary>
        /// Gets the content that will be written to the output without line breaks
        /// </summary>
        public MdSpan Content { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdSingleLineSpan"/>.
        /// </summary>
        /// <param name="content">The spans content</param>
        public MdSingleLineSpan(MdSpan content) =>
            Content = content ?? throw new ArgumentNullException(nameof(content));


        public override string ToString() => ToString(MdSerializationOptions.Default);

        public override string ToString(MdSerializationOptions options)
        {
            var content = Content.ToString(options);

            // remove trailing line breaks
            content = s_TrailingLineBreakRegex.Replace(content, "");

            // replace other line breaks with spaces.
            // If line breaks are followed/preceded by whitespace
            // replace whitespace and line break with a single
            // space
            content = s_LineBreakPattern.Replace(content, " ");

            return content;
        }

        public override bool DeepEquals(MdSpan other) => DeepEquals(other as MdSingleLineSpan);


        internal override MdSpan DeepCopy() => new MdSingleLineSpan(Content.DeepCopy());


        private bool DeepEquals(MdSingleLineSpan other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Content.DeepEquals(other.Content);
        }

    }
}
