namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines the available options for including text anchors for headings in the output.
    /// </summary>
    public enum MdHeadingAnchorStyle
    {
        /// <summary>
        /// Do not emit an anchor (default)
        /// </summary>
        None = 0,

        /// <summary>
        /// Include an anchor-tag (<c>&lt;a /&gt;</c>) for headings in the output
        /// </summary>
        Tag = 1
    }
}
