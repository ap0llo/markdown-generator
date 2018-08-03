using System;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a heading in a markdown document
    /// For specification see https://spec.commonmark.org/0.28/#atx-headings 
    /// respectively https://spec.commonmark.org/0.28/#setext-headings
    /// </summary>
    /// <remarks>
    /// If a heading is serialized as ATX heading (lines prefixed with '#') or as setext heading (underlined with '=' respectively '-')
    /// Is controlled using <see cref="MdSerializationOptions.HeadingStyle" /> property.
    /// See <see cref="MdSerializationOptions"/> for details.
    /// </remarks>
    public sealed class MdHeading : MdLeafBlock
    {
        /// <summary>
        /// The text of the heading
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
        /// Initializes a new instance of <see cref="MdHeading"/>
        /// </summary>
        /// <param name="text">The text of the heading. Must not be null.</param>
        /// <param name="level">The heading's level. Value must be in the range [1,6]</param>
        public MdHeading(MdSpan text, int level)
        {
            if (level < 1 || level > 6)
                throw new ArgumentOutOfRangeException(nameof(level), "Value must be in the range [1,6]");

            if (text == null)
                throw new ArgumentNullException(nameof(text));

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
        public MdHeading(int level, MdSpan text) : this(text, level)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdHeading"/>
        /// </summary>
        /// <param name="level">The heading's level. Value must be in the range [1,6]</param>
        /// <param name="text">The text of the heading. Must not be null.</param>
        public MdHeading(int level, params MdSpan[] text) : this(new MdCompositeSpan(text), level)
        { }
    }
}
