namespace Grynwald.MarkdownGenerator.Model
{
    public class MdSerializationOptions
    {
        /// <summary>
        /// Gets or sets the style for emphasized and strongly emphasized text
        /// </summary>
        public MdEmphasisStyle EmphasisStyle { get; set; } = MdEmphasisStyle.Asterisk;

        /// <summary>
        /// Gets or sets the style to use for thematic breaks
        /// </summary>
        public MdThematicBreakStyle ThematicBreakStyle { get; set; } = MdThematicBreakStyle.Dash;

        /// <summary>
        /// Gets or sets the style for headings
        /// </summary>
        public MdHeadingStyle HeadingStyle { get; set; } = MdHeadingStyle.Atx;
    }
}
