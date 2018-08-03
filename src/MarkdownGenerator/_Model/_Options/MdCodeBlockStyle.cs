namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines the available serializaton styles for fenced code blocks (see <see cref="MdCodeBlock"/>)
    /// For specification see https://spec.commonmark.org/0.28/#fenced-code-blocks
    /// </summary>
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
