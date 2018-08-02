namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines the available serializaton styles for tables (see <see cref="MdTable"/>).
    /// </summary>
    public enum MdTableStyle
    {
        /// <summary>
        /// Use GitHub Flavoured Markdown tables (default).
        /// See specification see https://github.github.com/gfm/#tables-extension-
        /// </summary>
        GFM = 0,

        /// <summary>
        /// Generate inline HTML for tables
        /// </summary>
        Html = 1,
    }
}
