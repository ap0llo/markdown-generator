namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines the available serialization styles for tables (see <see cref="MdTable"/>).
    /// </summary>
    public enum MdTableStyle
    {
        /// <summary>
        /// Use GitHub Flavored Markdown tables (default).
        /// See specification see <see href="https://github.github.com/gfm/#tables-extension-">GitHub Flavored Markdown Spec - Tables (extension)</see>.
        /// </summary>
        GFM = 0,

        /// <summary>
        /// Generate inline HTML for tables
        /// </summary>
        Html = 1,
    }
}
