namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines the available serialization styles for bullet lists (see <see cref="MdBulletList"/>).
    /// For specification see <see href="https://spec.commonmark.org/0.28/#list-items">CommonMark - List items</see>.
    /// </summary>
    /// <seealso cref="MdBulletList"/>
    public enum MdBulletListStyle
    {
        /// <summary>
        /// Start bullet list items with '-' (default)
        /// </summary>
        Dash = 0,

        /// <summary>
        /// Start bullet list items with '+'
        /// </summary>
        Plus = 1,

        /// <summary>
        /// Start bullet list items with '*'
        /// </summary>
        Asterisk = 2
    }
}
