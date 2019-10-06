namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines the available serialization styles for emphasis (see <see cref="MdEmphasisSpan"/>) and
    /// strong emphasis (see <see cref="MdStrongEmphasisSpan"/>).
    /// For specification see <see href="https://spec.commonmark.org/0.28/#emphasis-and-strong-emphasis">CommonMark - Emphasis and strong emphasis</see>.
    /// </summary>
    /// <seealso cref="MdEmphasisSpan"/>
    /// <seealso cref="MdStrongEmphasisSpan"/>
    public enum MdEmphasisStyle
    {
        /// <summary>
        /// Use '*' respectively '**' for (strongly) emphasized text.
        /// </summary>
        Asterisk = 0,

        /// <summary>
        /// Use '_' respectively '__' for (strongly) emphasized text.
        /// </summary>
        Underscore = 1
    }
}
