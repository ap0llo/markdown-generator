namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Provides an abstraction over converting text to be written into a Markdown file.
    /// </summary>
    /// <remarks>
    /// When text is written to a Markdown file, some characters with a syntactical meaning
    /// in Markdown need to be escaped.
    /// <para>
    /// As the way escaping works differs between some Markdown-to-HTML converters,
    /// the escaping can be customized.
    /// </para>
    /// </remarks>
    /// <seealso cref="MdSerializationOptions.TextFormatter"/>
    /// <seealso cref="DefaultTextFormatter"/>
    public interface ITextFormatter
    {
        /// <summary>
        /// Escapes the specified text.
        /// </summary>
        /// <param name="text">The text to process.</param>
        string EscapeText(string text);
    }
}
