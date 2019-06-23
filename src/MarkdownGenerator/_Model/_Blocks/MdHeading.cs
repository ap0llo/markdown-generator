using System;
using System.Text;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a heading in a markdown document.
    /// For specification see https://spec.commonmark.org/0.28/#atx-headings
    /// respectively https://spec.commonmark.org/0.28/#setext-headings.
    /// </summary>
    /// <remarks>
    /// If a heading is serialized as ATX heading (lines prefixed with '#') or as setext heading (underlined with '=' respectively '-')
    /// Is controlled using <see cref="MdSerializationOptions.HeadingStyle" /> property.
    /// See <see cref="MdSerializationOptions"/> for details.
    /// </remarks>
    public sealed class MdHeading : MdLeafBlock
    {
        private string m_Anchor;

        /// <summary>
        /// Gets the text of the heading.
        /// </summary>
        public MdSingleLineSpan Text { get; }

        /// <summary>
        /// Gets the level of the heading, 1 being the top-most heading.
        /// </summary>
        /// <remarks>
        /// Value will always be in the range of 1-6 (inclusive)
        /// </remarks>
        public int Level { get; }


        /// <summary>
        /// Gets the HTML anchor for this heading.
        /// </summary>
        /// <remarks>
        /// The HTML anchor can be used for linking to a heading within a page.
        /// It is automatically derived from the heading text by removing all
        /// punctuation, replacing spaces with dashes and converting the text to lower case.
        /// <para>
        /// Note: Text anchors are not part of the CommonMark spec so linking to this anchor
        /// might not work in every markdown implementation.
        /// </para>
        /// <para>
        /// The anchor does not include the leading '#' required for links.
        /// </para>
        /// </remarks>
        public string Anchor
        {
            get
            {
                if (m_Anchor == null)
                {
                    m_Anchor = GetAnchor();
                }
                return m_Anchor;
            }
        }


        /// <summary>
        /// Initializes a new instance of <see cref="MdHeading"/>
        /// </summary>
        /// <param name="text">The text of the heading. Must not be null.</param>
        /// <param name="level">The heading's level. Value must be in the range [1,6]</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="level"/> is less than 1 or greater than 6.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is <c>null</c>.</exception>
        public MdHeading(MdSpan text, int level)
        {
            if (level < 1 || level > 6)
                throw new ArgumentOutOfRangeException(nameof(level), "Value must be in the range [1,6]");

            if (text == null)
                throw new ArgumentNullException(nameof(text));

            // wrap into a single line span
            if (text is MdSingleLineSpan singleLineSpan)
            {
                Text = singleLineSpan;
            }
            else
            {
                Text = new MdSingleLineSpan(text);
            }

            Level = level;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MdHeading"/>
        /// </summary>
        /// <param name="level">The heading's level. Value must be in the range [1,6]</param>
        /// <param name="text">The text of the heading. Must not be null.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="level"/> is less than 1 or greater than 6.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is <c>null</c>.</exception>
        public MdHeading(int level, MdSpan text) : this(text, level)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdHeading"/>
        /// </summary>
        /// <param name="level">The heading's level. Value must be in the range [1,6]</param>
        /// <param name="text">The text of the heading. Must not be null.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="level"/> is less than 1 or greater than 6.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is <c>null</c>.</exception>
        public MdHeading(int level, params MdSpan[] text) : this(new MdCompositeSpan(text), level)
        { }


        /// <inheritdoc />
        public override bool DeepEquals(MdBlock other) => DeepEquals(other as MdHeading);


        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);


        private bool DeepEquals(MdHeading other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Level == other.Level &&
                   Text.DeepEquals(other.Text);
        }

        private string GetAnchor()
        {
            // There is no official spec for how anchors for headings work
            // This implementation follows the guidance here
            // https://stackoverflow.com/questions/27981247/github-markdown-same-page-link
            //
            // - leading white spaces will be dropped
            // - punctuation marks will be dropped
            // - upper case will be converted to lower
            // - spaces between letters will be converted to '-'

            var headingText = Text.ToString().Trim();

            if (String.IsNullOrEmpty(headingText))
                return "";

            var anchor = new StringBuilder();

            foreach(var c in headingText)
            {
                if(Char.IsLetter(c) || Char.IsNumber(c))
                {
                    anchor.Append(Char.ToLower(c));
                }
                else if(Char.IsWhiteSpace(c))
                {
                    anchor.Append('-');
                }
            }

            return anchor.ToString();
        }
    }
}
