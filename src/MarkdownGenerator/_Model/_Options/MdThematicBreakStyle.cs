namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines the available serialization styles for thematic breaks (see <see cref="MdThematicBreak"/>).
    /// For specification see <see href="https://spec.commonmark.org/0.28/#thematic-breaks">CommonMark - Thematic breaks</see>.
    /// </summary>
    /// <seealso cref="MdThematicBreak"/>
    public enum MdThematicBreakStyle
    {
        /// <summary>
        /// Use '___' for thematic breaks (default)
        /// </summary>
        Underscore = 0,

        /// <summary>
        /// Use '---' for thematic breaks
        /// </summary>
        Dash = 2,

        /// <summary>
        /// Use '***' for thematic breaks
        /// </summary>
        Asterisk = 1,
    }
}
