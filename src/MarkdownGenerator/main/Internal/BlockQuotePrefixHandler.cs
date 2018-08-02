namespace Grynwald.MarkdownGenerator.Internal
{
    /// <summary>
    /// Prefix handler for block quotes
    /// </summary>
    class BlockQuotePrefixHandler : IPrefixHandler
    {
        bool m_LineWritten = false;

        // do no prefix blank lines before the quote, then prefix all lines
        public string GetBlankLinePrefix() => m_LineWritten ? "> " : "";

        public string PreviewLinePrefix() => "> ";

        public string GetLinePrefix()
        {
            m_LineWritten = true;
            return "> ";
        }
    }
}
