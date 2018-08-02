namespace Grynwald.MarkdownGenerator
{
    public enum MdTableStyle
    {
        /// <summary>
        /// Use GitHub Flavoured Markdown tables (default)
        /// See https://github.github.com/gfm/#tables-extension- for details
        /// </summary>
        GFM = 0,

        /// <summary>
        /// Generate inline HTML for tables
        /// </summary>
        Html = 1,
    }
}
