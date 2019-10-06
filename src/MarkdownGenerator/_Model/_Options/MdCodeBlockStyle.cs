namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines the available serialization styles for fenced code blocks (see <see cref="MdCodeBlock"/>)
    /// For specification see <see href="https://spec.commonmark.org/0.28/#fenced-code-blocks">CommonMark - Fenced code blocks</see>.
    /// </summary>
    /// <seealso cref="MdCodeBlock"/>
    public enum MdCodeBlockStyle
    {
        /// <summary>
        /// Use backticks (`) to for fenced code blocks
        /// </summary>
        Backtick = 0,

        /// <summary>
        /// Use tildes (~) to for fenced code blocks
        /// </summary>
        Tilde = 1
    }
}
