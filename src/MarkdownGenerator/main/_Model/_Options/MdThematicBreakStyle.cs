namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines the available serializaton styles for thematic breaks (see <see cref="MdThematicBreak"/>).
    /// For specification see https://spec.commonmark.org/0.28/#thematic-breaks
    /// </summary>
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
