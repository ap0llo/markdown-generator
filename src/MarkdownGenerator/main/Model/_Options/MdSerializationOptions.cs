namespace Grynwald.MarkdownGenerator.Model
{
    public class MdSerializationOptions
    {

        public static readonly MdSerializationOptions Default = new MdSerializationOptions();

        /// <summary>
        /// Gets or sets the style for emphasized and strongly emphasized text
        /// </summary>
        public MdEmphasisStyle EmphasisStyle { get; set; } = MdEmphasisStyle.Asterisk;

        /// <summary>
        /// Gets or sets the style to use for thematic breaks
        /// </summary>
        public MdThematicBreakStyle ThematicBreakStyle { get; set; } = MdThematicBreakStyle.Underscore;

        /// <summary>
        /// Gets or sets the style for headings
        /// </summary>
        public MdHeadingStyle HeadingStyle { get; set; } = MdHeadingStyle.Atx;

        /// <summary>
        /// Gets or sets the style of code blocks
        /// </summary>
        public MdCodeBlockStyle CodeBlockStyle { get; set; } = MdCodeBlockStyle.Backtick;

        /// <summary>
        /// Gets or sets the style for bullet list items
        /// </summary>
        public MdBulletListStyle BulletListStyle { get; set; } = MdBulletListStyle.Dash;

        /// <summary>
        /// Gets or sets the style for ordered list items
        /// </summary>
        public MdOrderedListStyle OrderedListStyle { get; set; } = MdOrderedListStyle.Dot;

        /// <summary>
        /// The maximum length of a line in the output.
        /// When set to a value greater than 0, linebreaks
        /// will be inserted after the specified number of characters
        /// when possible.        
        /// </summary>
        /// <remarks>
        /// Not all types of blocks can be split into multiple lines. 
        /// Also line breaks will only be inserted between words, so if 
        /// the length of a word exceeds the maximum line length the max length
        /// cannot be adhered to
        /// </remarks>
        public int MaxLineLength { get; set; } = -1;
    }
}
